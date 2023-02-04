using AntiAlphA.Data;
using AntiAlphA.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;


namespace AntiAlphA.Functions
{
    public class CheckChrome
    {
        public static string checkchrome()
        {
            Process[] procsChrome = Process.GetProcessesByName("chrome");

            if (procsChrome.Length <= 0)
                return null;

            foreach (Process proc in procsChrome)
            {
                // the chrome process must have a window 
                if (proc.MainWindowHandle == IntPtr.Zero)
                    continue;

                // to find the tabs we first need to locate something reliable - the 'New Tab' button 
                AutomationElement root = AutomationElement.FromHandle(proc.MainWindowHandle);
                var SearchBar = root.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, "Address and search bar"));
                if (SearchBar != null)
                     
                    
                    
                    return (string)SearchBar.GetCurrentPropertyValue(ValuePatternIdentifiers.ValueProperty);
            }

            return null;
        }


        public async static void scan_chrome()
        {
            while(true)
            {
                string domain = checkchrome();
                if (domain == "" || domain == null)
                {
                    continue;
                }
                domain = NormalUrl.normalurl(domain);
                
                using (var db = new ApplicationDbContext())
                {
                    if (!db.RequestUs.Where(R => R.URL == domain).Any())
                    {
                        Random rnd = new Random();
                        int randIndex = rnd.Next(Setting.myapikey.Count);
                        string randomkey = Setting.myapikey[randIndex];
                        ScanUrl.scanurl(randomkey, domain);
                    }

                }
                Thread.Sleep(1000);
                

                

            }
        }

    }
}
