using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiAlphA.Model
{
    public class ScanedModel
    {
        public string FileDirectory { get; set; }
        public bool Secure { get; set; }
        public DateTime ScanedRequest { get; set; }
        public DateTime ScanedTime { get; set; }
    }
}
