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
    public class ReportF
    {
        public async static void reportfiles(string myapikey)
        {
            while (true)
            {
                
                var client = new HttpClient();
                string pubrequesturl = "https://www.virustotal.com/vtapi/v2/file/report?apikey=" + myapikey + "&resource=";
                List<RequestF> requestFList = new List<RequestF>();
                using (var db = new ApplicationDbContext())
                {
                    requestFList = db.RequestFs.Where(R => R.state == false).ToList();

                }
                foreach (var requestF in requestFList)
                {
                    string requesturl = pubrequesturl + requestF.Resource + "&" + "allinfo=false";
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri(requesturl),
                    };
                    while (true)
                    {


                        try
                        {
                            var response =  client.Send(request);
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
                                
                                
                                var stud = new ResponseF() {  ReqId = requestF.Id , Secure = secure , Time = DateTime.Now  };

                                db.ResponseFs.Add(stud);
                                var newreq = requestF;
                                newreq.state = true;
                                db.Entry(newreq).State = EntityState.Modified;


                                db.SaveChanges();
                                

                            }

                            if (!secure)
                            {
                                string allert = requestF.FimeName + " " + "is NOT Secure";
                                
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
