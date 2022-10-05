﻿namespace ProjectBootcampNet.Models
{
    public class StudentModel
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public List<StudentQuotes> Studentquotes { get; set; }
     
        // public ICollection<Enrollment> Enrollments { get; set; }

    }
}
