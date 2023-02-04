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
    public partial class FileQueue : Form
    {
        public FileQueue()
        {
            InitializeComponent();
        }

        private void FileQueue_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            List<int> reqids = new List<int>();
            Thread t3 = new Thread(() =>
            {
                List<QueueModel> NotScanedFiles = new List<QueueModel>();

                while (true)
                {




                    using (var db = new ApplicationDbContext())
                    {
                        List<RequestF> requestFsScaned = new List<RequestF>();
                        requestFsScaned = db.RequestFs.Where(r => r.state == false).ToList();
                        foreach (var item in requestFsScaned)
                        {
                            if (!reqids.Contains(item.Id))
                            {
                                reqids.Add(item.Id);

                                
                                QueueModel model = new QueueModel() { Name = item.FimeName, Time = item.Time };

                                NotScanedFiles.Add(model);
                            }

                        }

                    }
                    foreach (var item in NotScanedFiles)
                    {
                        dataGridView1.Rows.Add(item.Name, item.Time);
                    }
                    NotScanedFiles = new List<QueueModel>();
                    Thread.Sleep(20000);
                }
            });
            t3.Start();
        }
    }
}
