using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SettingsApp.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {


            //ValutypeInformation();
            PictureSaver();

            //var valueTypenesne = ResimKaydet("afsfasf");
            //var deger1 = valueTypenesne.Item1;
            //var deger2 = valueTypenesne.Item2;
            //var deger3 = valueTypenesne.Item4;

        }
        //Bir metottan birden fazla değer döndürme !
        public (string, string,int,object) ResimKaydet(string HttpPostedFileBase)
        {

            //Image orj = Image.FromStream(temp.InputStream);

            //Bitmap kck = new Bitmap(orj, Setting.KucukResimWH());
            //Bitmap byk = new Bitmap(orj, Setting.BuyukResimWH());
            //string dosyaAdi = Guid.NewGuid() + Path.GetExtension(temp.FileName);

            //kck.Save(Server.MapPath("/Content/images/Resim/Kucuk/" + dosyaAdi));
            //orj.Save(Server.MapPath("/Content/images/Resim/Buyuk/" + dosyaAdi));
            //string x1 = "/Content/images/Resim/Kucuk/" + dosyaAdi;
            //string x2 = "/Content/images/Resim/Buyuk/" + dosyaAdi;

            string x1 = "selam";
            string x2 = "as";
            
            return (x1, x2,3,new denemeClass() { Id = 5, Name = "tamam" });
        }

        public class denemeClass
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public void ValutypeInformation()
        {
            
          ValueTuple<int,string> safasf  =ValueTuple.Create(3, "asf");
            ValueTuple<int, string> safasf2 = ValueTuple.Create(3, "asB");

            ValueTuple valueTuple = new ValueTuple();



       var deger=     valueTuple.CompareTo(new ValueTuple());
        }

        public void PictureSaver()
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                pictureBox1.Image = new Bitmap(open.FileName);
                
                // image file path  

            }

            Image orj = Image.FromFile(open.FileName);

            Bitmap kck = new Bitmap(orj, new Size(100, 120));
            kck.Save(@"D:/yeni.png");


        }
    }
}
