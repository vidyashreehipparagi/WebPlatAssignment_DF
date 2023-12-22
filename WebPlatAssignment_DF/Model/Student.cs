using System.ComponentModel.DataAnnotations.Schema;

namespace WebPlatAssignment_DF.Model
{
    [Table("student")]
    public class Student
    {
        public int Id { get; set; }
        public string? SName { get; set; }
        public string? Course { get; set; }
        public int Marks { get; set; }


    }
}
