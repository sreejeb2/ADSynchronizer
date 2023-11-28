using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADSynchronizer
{
    public class ImportableStudent
    {
        public int Student_Id { get; set; }
        public string Name { get; set; }
        public string Personal_Number { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Profile_Image { get; set; }
        public string Gender { get; set; }
        public string Access_Card_Number { get; set; }
        public bool Status { get; set; }
        public string Remember_Token { get; set; }
        public int Semester_Id { get; set; }
        public long Department_Id { get; set;}

    }
}
