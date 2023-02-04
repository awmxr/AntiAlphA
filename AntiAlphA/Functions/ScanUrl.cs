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
    public class ScanUrl
    {
        public async static void scanurl(string myapikey , string url)
        {
            if (url == null || !url.Contains("."))
            {
                return;
            }
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://www.virustotal.com/vtapi/v2/url/scan"),
                Headers =
                {
                    { "accept", "application/json" },
                },
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "apikey", myapikey },
                    { "url", url },
                }),
            };
            

            //var responseString = response.ReadAsStringAsync();
            JsonObject x = new JsonObject();
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
            
            
            
            using (var db = new ApplicationDbContext())
            {
                if (!db.RequestUs.Where(R => R.URL == url).Any())
                {
                    var stud = new RequestU() { URL = url, Resource = x["url"].ToString(), State = false, Time = DateTime.Now };

                    db.RequestUs.Add(stud);
                    db.SaveChanges();
                }

            }
        }
    }
}
