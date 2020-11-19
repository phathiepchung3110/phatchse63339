using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DTOS.Student
{
    public class StudentResponse
    {
        public string Code { get; set; }
        public string Email { get; set; }
        public string Fullname { get; set; }
        public string PhoneNo { get; set; }
        public string Cv { get; set; }
        public double? Gpa { get; set; }
        public string MajorCode { get; set; }
        public string UniCode { get; set; }
    }
}
