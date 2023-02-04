using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiAlphA.Functions
{
    public class NormalUrl
    {
        public static string normalurl(string url)
        {
            url = url.Replace("https://", "");
            url = url.Replace("http://", "");
            var x = url.Split("/")[0];
            url = x;

            return url;
        }
    }
}
