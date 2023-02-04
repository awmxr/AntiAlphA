using AntiAlphA.Data;
using AntiAlphA.Functions;
using AntiAlphA.Model;
using System.Windows.Automation;

namespace AntiAlphA
{
    public partial class Form1 : Form
    {
        private readonly ApplicationDbContext _db;
        public Form1(ApplicationDbContext db)
        {
            InitializeComponent();
            _db = db;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ScanFile.scanfile(myapikey:Setting.myapikey);

            //ReportF.reportfiles(myapikey: Setting.myapikey);
            //ScanUsb.scanusp();

            //var x = CheckChrome.checkchrome();
            //x = NormalUrl.normalurl(x);
            //MessageBox.Show(x);
            //CheckChrome.scan_chrome();

            var scanedurlform = new UrlScaned();
            scanedurlform.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var scanedfilesform = new FileScaned();
            scanedfilesform.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            int maxsize = _db.MaxSizes.First().Size;
            numericUpDown1.Value = maxsize;

            Thread t1 = new Thread(ScanUsb.scanusp);
            Random rnd = new Random();
            int randIndex = rnd.Next(Setting.myapikey.Count);
            string randomkey = Setting.myapikey[randIndex];

            Thread t2 = new Thread(() => ReportF.reportfiles(randomkey));
            Thread t3 = new Thread(CheckChrome.scan_chrome);

            rnd = new Random();
            randIndex = rnd.Next(Setting.myapikey.Count);
            randomkey = Setting.myapikey[randIndex];
            Thread t4 = new Thread(() => ReportU.reporturl(randomkey));

            Thread t5 = new Thread(() =>
            {
                while(true)
                {
                    if (CheckConection.CheckForInternetConnection())
                    {
                        label2.Text = "Connection Status : True";
                        label2.ForeColor = Color.Green;
                    }
                    else
                    {
                        label2.Text = "Connection Status : False";
                        label2.ForeColor = Color.Red;
                    }
                    Thread.Sleep(10000);
                }
                
            }

            );
            t5.Start();
            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();


        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var maxsize = numericUpDown1.Value;
            var maxS = _db.MaxSizes.First();
            maxS.Size = (int)maxsize;
            _db.Entry(maxS).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var scanedfilesformQueue = new FileQueue();
            scanedfilesformQueue.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var scanedurlformQueue = new UrlQueue();
            scanedurlformQueue.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = openFileDialog1.FileName;
                

                Random rnd = new Random();
                int randIndex = rnd.Next(Setting.myapikey.Count);

                ScanFile.scanfile(Setting.myapikey[randIndex], selectedFileName);

                MessageBox.Show(selectedFileName + "Uploaded to VirusTotal Server for Scan");
                //...
            }

        }
    }
}