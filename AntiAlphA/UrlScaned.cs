using AntiAlphA.Data;
using AntiAlphA.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntiAlphA
{
    public partial class UrlScaned : Form
    {
        public UrlScaned()
        {
            InitializeComponent();
        }

        private void UrlScaned_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            
            Thread t3 = new Thread(() =>
            {
                List<int> reqids = new List<int>();
                List<ScanedModel> ScanedFiles = new List<ScanedModel>();

                while (true)
                {




                    using (var db = new ApplicationDbContext())
                    {
                        List<RequestU> requestUsScaned = new List<RequestU>();
                        requestUsScaned = db.RequestUs.Where(r => r.State == true).ToList();
                        foreach (var item in requestUsScaned)
                        {
                            if (!reqids.Contains(item.Id))
                            {
                                reqids.Add(item.Id);

                                ResponseU response = db.ResponseUs.Where(r => r.ReqId == item.Id).FirstOrDefault();
                                ScanedModel model = new ScanedModel() { FileDirectory = item.Resource, Secure = response.Secure, ScanedRequest = item.Time, ScanedTime = response.Time };

                                ScanedFiles.Add(model);
                            }

                        }

                    }
                    foreach (var item in ScanedFiles)
                    {
                        dataGridView1.Rows.Add(item.FileDirectory, item.Secure, item.ScanedRequest, item.ScanedTime);
                    }
                    ScanedFiles = new List<ScanedModel>();
                    Thread.Sleep(20000);
                }
            });
            t3.Start();
        }
    }
}
