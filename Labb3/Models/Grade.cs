using System;
using System.Collections.Generic;

namespace Labb3.Models
{
    public partial class Grade
    {
        public Grade()
        {
            TakingSubjects = new HashSet<TakingSubject>();
        }

        public int GradeId { get; set; }
        public string? GradeLetter { get; set; }

        public virtual ICollection<TakingSubject> TakingSubjects { get; set; }
    }
}
