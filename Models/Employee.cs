using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace k_love.Models
{
    public class Employee
    {   [Key]
        public int EmpId { get; set; }
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Age")]
        public int Age { get; set; }
        [DisplayName("Salary")]
        public int Salary { get; set; }
        [DisplayName("Role")]
        public string Role { get; set; }
        public string Location { get; set; }
        public int DeptId { get; set; }
    }
}
