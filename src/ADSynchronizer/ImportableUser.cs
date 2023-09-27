using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADSynchronizer
{
    public class ImportableUser
    {
        public string DistiguishedName { get; set; }
        public string Sid { get; set; }
        public string DisplayName { get; set; }
        public string SamAccountName { get; set; }
        public string Email { get; set; }
    }
}
