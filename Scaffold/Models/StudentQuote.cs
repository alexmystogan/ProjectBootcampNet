using System;
using System.Collections.Generic;

namespace Scaffold.Models
{
    public partial class StudentQuote
    {
        public int Id { get; set; }
        public string Text { get; set; } = null!;
        public int StudentId { get; set; }

        public virtual Student Student { get; set; } = null!;
    }
}
