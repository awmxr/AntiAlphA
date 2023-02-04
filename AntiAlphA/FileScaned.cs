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
    public partial class FileScaned : Form
    {
        public FileScaned()
        {
            InitializeComponent();
        }

        private void FileScaned_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            List<int> reqids = new List<int>();
            Thread t3 = new Thread(() =>
            {
                List<ScanedModel> ScanedFiles = new List<ScanedModel>();
                
                while (true)
                {


                    

                    using (var db = new ApplicationDbContext())
                    {
                        List<RequestF> requestFsScaned = new List<RequestF>();
                        requestFsScaned = db.RequestFs.Where(r => r.state == true).ToList();
                        foreach (var item in requestFsScaned)
                        {
                            if (!reqids.Contains(item.Id))
                            {
                                reqids.Add(item.Id);

                                ResponseF response = db.ResponseFs.Where(r => r.ReqId == item.Id).FirstOrDefault();
                                ScanedModel model = new ScanedModel() { FileDirectory = item.FimeName, Secure = response.Secure, ScanedRequest = item.Time, ScanedTime = response.Time };

                                ScanedFiles.Add(model);
                            }

                        }

                    }
                    foreach (var item in ScanedFiles)
                    {
                        dataGridView1.Rows.Add(item.FileDirectory, item.Secure, item.ScanedRequest, item.ScanedTime);
                    }
                    ScanedFiles = new  List<ScanedModel>();
                    Thread.Sleep(20000);
                }
            });
            t3.Start();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
