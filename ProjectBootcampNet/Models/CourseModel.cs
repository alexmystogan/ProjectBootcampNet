using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectBootcampNet.Models
{
    [Keyless]
    public class CourseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
       // public ICollection<Enrollment> Enrollments { get; set; }

    }
}
