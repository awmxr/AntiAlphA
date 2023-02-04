using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiAlphA.Functions
{
    public class CheckUsb
    {
        public static bool checkusb()
        {
            List<string> usb = new List<string>() { "A", "B", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            foreach (string s in usb)
            {
                string path = s + ":";
                if (Directory.Exists(path))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
