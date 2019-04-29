using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormToApi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private async void button1_Click(object sender, EventArgs e)
        {
            //Client durumundayız apiye bağlanıp dataları çekeceğiz.
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8091");
            HttpResponseMessage response = await client.GetAsync("api/city");
            //HttpResponseMessage response = await client.GetAsync("api/city/2");

            string result = await response.Content.ReadAsStringAsync();
            label1.Text = result;

        }
    }
}
