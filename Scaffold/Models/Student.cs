using System;
using System.Collections.Generic;

namespace Scaffold.Models
{
    public partial class Student
    {
        public Student()
        {
            StudentQuotes = new HashSet<StudentQuote>();
        }

        public int Id { get; set; }
        public string LastName { get; set; } = null!;
        public string FirstMidName { get; set; } = null!;
        public DateTime EnrollmentDate { get; set; }

        public virtual ICollection<StudentQuote> StudentQuotes { get; set; }
    }
}
