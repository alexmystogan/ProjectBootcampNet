﻿using System;
using System.Collections.Generic;

namespace Scaffold.Models
{
    public partial class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; } = null!;
        public int Credits { get; set; }
    }
}
