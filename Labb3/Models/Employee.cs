using System;
using System.Collections.Generic;

namespace Labb3.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Subjects = new HashSet<Subject>();
        }

        public int EmployeeId { get; set; }
        public string? PersonalNumber { get; set; }
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public string? Gender { get; set; }
        public int? FkRoleId { get; set; }

        public virtual Role? FkRole { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
