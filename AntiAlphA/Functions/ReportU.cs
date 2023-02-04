using AntiAlphA.Data;
using AntiAlphA.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace AntiAlphA.Functions
{
    public class ReportU
    {
        public async static void reporturl(string myapikey)
        {
            while (true)
            {

                var client = new HttpClient();
                string pubrequesturl = "https://www.virustotal.com/vtapi/v2/file/report?apikey=" + myapikey + "&resource=";
                List<RequestU> requestUList = new List<RequestU>();
                using (var db = new ApplicationDbContext())
                {
                    requestUList = db.RequestUs.Where(R => R.State == false).ToList();

                }
                string puburl = "https://www.virustotal.com/vtapi/v2/url/report?apikey=" + myapikey + "&" + "resource=";
                foreach (var requestU in requestUList)
                {

                    puburl += requestU.Resource + "&allinfo=false&scan=0";
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri(puburl),
                        Headers =
                        {
                            { "accept", "application/json" },
                        },
                    };
                    while (true)
                    {


                        try
                        {
                            var response = client.Send(request);
                            var responseString = await response.Content.ReadAsStringAsync();

                            //var responseString = response.ReadAsStringAsync();
                            var x = JsonSerializer.Deserialize<JsonObject>(responseString);
                            if (!x["verbose_msg"].ToString().Contains("finished"))
                            {
                                Thread.Sleep(10000);
                                continue;

                            }
                            string positives = x["positives"].ToString();
                            bool secure = true;
                            if (positives != "0")
                            {
                                secure = false;

                            }
                            //MessageBox.Show(x["possitive"].ToString());
                            using (var db = new ApplicationDbContext())
                            {


                                var stud = new ResponseU() { ReqId = requestU.Id, Secure = secure, Time = DateTime.Now };

                                db.ResponseUs.Add(stud);
                                var newreq = requestU;
                                newreq.State = true;
                                db.Entry(newreq).State = EntityState.Modified;


                                db.SaveChanges();


                            }
                            if (!secure)
                            {
                                string allert = requestU.URL + " " + "is NOT Secure";
                                
                                MessageBox.Show(allert);
                            }
                            break;

                        }
                        catch (Exception)
                        {
                            Random rnd = new Random();
                            int randIndex = rnd.Next(Setting.myapikey.Count);
                            myapikey = Setting.myapikey[randIndex];
                            Thread.Sleep(10000);
                            continue;

                        }
                        Thread.Sleep(10000);
                    }

                }
                Thread.Sleep(10000);

            }

        }
    }
}
