using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiAlphA.Model
{
    public class RequestF
    {
        public int Id { get; set; }
        public string FimeName { get; set; }
        public int Size { get; set; }
        public string Resource { get; set; }
        public bool state { get; set; }
        public DateTime Time { get; set; }
        public string Sha256 { get; set; }
        
    }
}
