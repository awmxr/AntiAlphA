using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiAlphA.Functions
{
    public class ScanUsb
    {
        public static void scanusp()
        {
            List<string> usb = new List<string>() { "A", "B", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            List<string> pathss = new List<string>();
            List<string> subdirs = new List<string>();
            List<string> subdirs2 = new List<string>();
            //Directory.GetDirectories(rootPath, "*", SearchOption.TopDirectoryOnly);
            //Directory.GetDirectories(rootPath, "*", SearchOption.TopDirectoryOnly);

            while (true)                                                
            {

                subdirs = new List<string>();
                if (CheckUsb.checkusb())
                {
                    MessageBox.Show("usb in !");
                    foreach (string s in usb)
                    {
                        string path = s + ":";
                        if (Directory.Exists(path))
                        {
                            List<string> dirs =  GetDirs.GetAllAccessibleFiles(path);
                            foreach (string dir in dirs)
                            {
                                subdirs.Add(dir);
                            }
                            
                            
                            
                            try
                            {
                                


                                foreach (string file in dirs)
                                {
                                    if (file.ToLower().Contains("s0"))
                                    {
                                        continue;
                                    }
                                    string file2 = file.Replace("\\", "/");
                                    FileInfo info = new FileInfo(file2);
                                    if (info.Exists)
                                    {
                                        //MessageBox.Show(file2);
                                        Thread.Sleep(5000);

                                        Random rnd = new Random();
                                        int randIndex = rnd.Next(Setting.myapikey.Count);
                                        
                                        ScanFile.scanfile(Setting.myapikey[randIndex], file2);
                                    }
                                    
                                }
                            }
                            catch (System.UnauthorizedAccessException e)
                            {
                                
                                
                            }
                            

                            
                        }
                    }
                    while(true)
                    {
                        subdirs2 = new List<string>();


                        foreach (var item in usb)
                        {
                            string path = item + ":";
                            if (Directory.Exists(path))
                            {
                                List<string> dirs2 = GetDirs.GetAllAccessibleFiles(path);
                                foreach(string dir2 in dirs2)
                                {
                                    subdirs2.Add(dir2);
                                }
                            }
                        }
                        if (subdirs.Count != subdirs2.Count)
                        {
                            break;
                        }
                        else
                        {
                            Thread.Sleep(1000);
                        }
                    }
                    

                }
                Thread.Sleep(2000);
            }
        }
    }
}

