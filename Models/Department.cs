using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace k_love.Models
{
   
    public class Department
    {
        public int Id { get; set; }
        
        [Required]
        [DisplayName("Name")]
        public string DeptName { get; set; }

        public List<Employee> Employee { get; set; }
       
    }
}
