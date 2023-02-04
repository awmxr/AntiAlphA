using AntiAlphA.Data;
using AntiAlphA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace AntiAlphA.Functions
{
    public class ScanFile
    {
        public async static void scanfile(string myapikey , string file = "D:/Amir/UMZ/Hozuri/07/Sec/project/nava/main.py")
        {
            int maxSize;
            using (var db = new ApplicationDbContext())
            {

                maxSize = db.MaxSizes.First().Size;
            }
            FileInfo info = new FileInfo(file);

            int size = Int32.Parse(info.Length.ToString());
            if (size > maxSize)
            {
                string allert = "The maximum size should be at most " + maxSize.ToString() + " Byte\n" + "But " + file + "'s Size is " + size.ToString();
                MessageBox.Show(allert);
                return;
            }

            
            
            

            Byte[] bytes = File.ReadAllBytes(file);
            String file64 = Convert.ToBase64String(bytes);
            
            List<string> files = new List<string>();
            files = file.Split('/').ToList();
            
            string filename = files.Last();

            string filecontent = "data:application/octet-stream;name=" + filename + ";base64," +file64;
            //MessageBox.Show(filecontent);



            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://www.virustotal.com/vtapi/v2/file/scan"),
                Headers =
                    {
                        { "accept", "text/plain" },
                    },
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "apikey", myapikey },
                    { "file", filecontent },

                }),
            };
            var x = new JsonObject();
            try
            {
                var response = client.Send(request);
                var responseString = await response.Content.ReadAsStringAsync();
                x = JsonSerializer.Deserialize<JsonObject>(responseString);
            }
            catch
            {
                return;
            }
            
            

            //var responseString = response.ReadAsStringAsync();
            
             
              
            
            //MessageBox.Show(x["resource"].ToString());
            string sha265 = x["sha256"].ToString();
            using (var db = new ApplicationDbContext())
            {
                if(!db.RequestFs.Where(R => R.Sha256 == sha265).Any() )
                {
                    var stud = new RequestF() { FimeName = file, Resource = x["resource"].ToString(), Sha256 = x["sha256"].ToString(), Size = size, state = false, Time = DateTime.Now };

                    db.RequestFs.Add(stud);
                    db.SaveChanges();
                }
                
            }


        }
    }
}
