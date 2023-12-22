using Dapper;
using System.Data;
using WebPlatAssignment_DF.Data;
using WebPlatAssignment_DF.Model;

namespace WebPlatAssignment_DF.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext context;
        public StudentRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<int> AddStudent(Student student)
        {
            int result = 0;
            var parameter = new DynamicParameters();
            parameter.Add("@sname", student.SName);
            parameter.Add("@course", student.Course);
            parameter.Add("@marks", student.Marks);

            using(var connection=context.CreateConnection())
            {
                result = await connection.ExecuteAsync("sp_AddStudent", parameter, commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        public async Task<int> DeleteStudent(int id)
        {
            int result = 0;
            using(var connection = context.CreateConnection())
            {
                result=await connection.ExecuteAsync("sp_DeleteStudent", new {id},commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        public async Task<Student> GetStudentById(int id)
        {
            using(var connection= context.CreateConnection())
            {
                var result = await connection.QuerySingleOrDefaultAsync<Student>("sp_GetStudentById", new { id }, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            using(var connection = context.CreateConnection())
            {
                var result=await connection.QueryAsync<Student>("sp_GetAllStudent",commandType: CommandType.StoredProcedure);
                return result.ToList();            
            }
        }

        public async Task<int> UpdateStudent(Student student)
        {
            int result = 0;
            var parameters = new DynamicParameters();
            parameters.Add("@sname", student.SName);
            parameters.Add("@course", student.Course);
            parameters.Add("@marks", student.Marks);
            parameters.Add("@id", student.Id);
         using(var connection=context.CreateConnection())
            {
                 result=await connection.ExecuteAsync("sp_UpdateStudent",parameters,commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
