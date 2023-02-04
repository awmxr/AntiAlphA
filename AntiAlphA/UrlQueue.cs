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
    public partial class UrlQueue : Form
    {
        public UrlQueue()
        {
            InitializeComponent();
        }

        private void UrlQueue_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            List<int> reqids = new List<int>();
            Thread t3 = new Thread(() =>
            {
                List<QueueModel> NotScanedUrls = new List<QueueModel>();

                while (true)
                {




                    using (var db = new ApplicationDbContext())
                    {
                        List<RequestU> requestUsScaned = new List<RequestU>();
                        requestUsScaned = db.RequestUs.Where(r => r.State == false).ToList();
                        foreach (var item in requestUsScaned)
                        {
                            if (!reqids.Contains(item.Id))
                            {
                                reqids.Add(item.Id);


                                QueueModel model = new QueueModel() { Name = item.Resource, Time = item.Time };

                                NotScanedUrls.Add(model);
                            }

                        }

                    }
                    foreach (var item in NotScanedUrls)
                    {
                        dataGridView1.Rows.Add(item.Name, item.Time);
                    }
                    NotScanedUrls = new List<QueueModel>();
                    Thread.Sleep(20000);
                }
            });
            t3.Start();
        }
    }
}
