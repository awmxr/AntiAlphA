using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiAlphA.Model
{
    public class RequestU
    {
        public int Id { get; set; }
        public string URL { get; set; }
        public string Resource { get; set; }
        public bool State { get; set; }
        public DateTime Time { get; set; }
        
    }
}
