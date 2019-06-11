using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WindowsService1
{
    
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }
        Timer timer = new Timer();
        string dosyaYolu = "d:\\winserlog.txt";
        protected override void OnStart(string[] args)
        {
            File.AppendAllText(dosyaYolu, "Başladı " + DateTime.Now.ToString() + " \r \n");
            timer.Elapsed += Timer_Elapsed;
            timer.Interval = 1000;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            File.AppendAllText(dosyaYolu, "Çalışıyor " + DateTime.Now.ToString() + " \r \n");
        }

        protected override void OnStop()
        {
            File.AppendAllText(dosyaYolu, "Durdu " + DateTime.Now.ToString() + " \r \n");
            timer.Enabled = false;

        }
        protected override void OnContinue()
        {
            File.AppendAllText(dosyaYolu, "Devam durumunda " + DateTime.Now.ToString() + " \r \n");
            timer.Enabled = true;
        }
        protected override void OnPause()
        {
            File.AppendAllText(dosyaYolu, "Beklemede " + DateTime.Now.ToString() + " \r \n");
            timer.Enabled = false;
        }

        protected override void OnShutdown()
        {
            File.AppendAllText(dosyaYolu, "Kapatıldı " + DateTime.Now.ToString() + " \r \n");
            timer.Enabled = false;
        }
    }
}
