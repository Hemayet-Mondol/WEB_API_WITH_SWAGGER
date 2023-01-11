using System.ComponentModel.DataAnnotations;
namespace TestAPI.Models;

    public class Student
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public Course Courses { get; set; }
        public DateTime AddmissionDate { get; set; }

    }
    public enum Course
        {
            VB,SQL,Csharp
        }

