﻿using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class UniversitySemester
    {
        public string SemesterCode { get; set; }
        public string UniCode { get; set; }

        public virtual Semester SemesterCodeNavigation { get; set; }
        public virtual University UniCodeNavigation { get; set; }
    }
}
