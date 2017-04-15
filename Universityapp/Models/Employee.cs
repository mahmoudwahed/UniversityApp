using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Universityapp.Models
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public string EmployeeAdress { get; set; }
        public bool? Gendre { get; set; }
        public bool? HaveInsurancef { get; set; }
    }
}
