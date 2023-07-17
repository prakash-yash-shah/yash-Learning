using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class EmployeeModel
    {
        [Key]
        public int EmpId { get; set; }

        public string EmpName { get; set; }

        public string EmpEmail { get; set; }

        public string EmpCity { get; set; }

        public bool EmpGender { get; set; }

    }
}