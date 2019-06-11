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
using WindowsService1.Enum;
using WindowsService1.Model;

namespace WindowsService1
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }
        WinSerContext winSerContext = new WinSerContext();

        List<EylemTurleri> eylemTurleri = new List<EylemTurleri>();
        protected override void OnStart(string[] args)
        {
            //Görevi bir yeri izlemek
            FileSystemWatcher fileSystemWatcher = new FileSystemWatcher(@"D:\", "*.txt");
            //Eventlerinden yakalayacağız

            eylemTurleri = winSerContext.EylemTurleris.ToList();

            fileSystemWatcher.Created += FileSystemWatcher_Created;

            fileSystemWatcher.Deleted += FileSystemWatcher_Deleted;

            fileSystemWatcher.Changed += FileSystemWatcher_Changed;

            fileSystemWatcher.Renamed += FileSystemWatcher_Renamed;

        }

        #region fileSystemAllEvents

        private void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            DosyaOlayCreator(EylemTurleriEnum.Create, e);

        }

        private void FileSystemWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            DosyaOlayCreator(EylemTurleriEnum.Delete, e);

        }

        private void FileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            DosyaOlayCreator(EylemTurleriEnum.Change, e);
        }

        private void FileSystemWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            DosyaOlayCreator(EylemTurleriEnum.Rename, e);
        }

        #endregion

        public void DosyaOlayCreator(EylemTurleriEnum eylemTuru, FileSystemEventArgs e)
        {
            var eylemTuruString= eylemTurleri.ToString();

            DosyaOlaylari dosyaOlaylari = new DosyaOlaylari();
            dosyaOlaylari.EventTurId = eylemTurleri.FirstOrDefault(x => x.Ad.Contains(eylemTuruString)).Id;
            dosyaOlaylari.Tarih = DateTime.Now;
            dosyaOlaylari.Yol = e.FullPath;
            winSerContext.DosyaOlaylaris.Add(dosyaOlaylari);
            winSerContext.SaveChanges();
        }

        protected override void OnStop()
        {

        }

    }
}
