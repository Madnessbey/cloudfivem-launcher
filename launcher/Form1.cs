using madnesslauncher;
using EpEren.Fivem.ServerStatus.BaseAPI;
using System;
using MaintenanceDiscordRPC;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Microsoft.Win32;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace BasicLuancher
{
    public partial class Form1 : Form
    {
        ayarlar madness = new ayarlar();
        Point lastPoint;
        Fivem Server;


        public string Ip { get; }
        public int Port { get; }

        public Form1()
        {
 
            InitializeComponent();
            Ip = "000000.000.0000";
            Port = 8403;
            madness.hileDurdur();
            this.BackColor = Color.DarkRed;
            this.TransparencyKey = Color.DarkRed;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
  
            Server = new Fivem("cfxkod");
            GetStat();
            Rpc.SetupRpc();
        }

        void GetStat()
        {
            if (Server.GetStatu())
            {
                labelCount.Text = " " + Server.GetOnlinePlayersCount().ToString() + " / " + Server.GetMaxPlayersCount() + " OYUNCU";
            }
            else
            {
                labelCount.Text = "SUNUCU BAKIMDA";
                labelCount.ForeColor = Color.Red;
            }
        }

        private string GetPublicIpAddress()
        {
            var request = (HttpWebRequest)WebRequest.Create("http://ifconfig.me");

            request.UserAgent = "curl"; // this will tell the server to return the information as if the request was made by the linux "curl" command

            string publicIPAddress;

            request.Method = "GET";
            using (WebResponse response = request.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    publicIPAddress = reader.ReadToEnd();
                }
            }

            return publicIPAddress.Replace("\n", "");
        }

        private void Postrequest(string ipadress)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://000000.000.0000/JoinApi/Create.php");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (WebClient client = new WebClient())
                {
                    client.UploadString(httpWebRequest.Address, ipadress);
                }
            }
            catch (WebException ex)
            {

                DialogResult result = MessageBox.Show("İşlemler esnasında bir hata oluştu, bağlantı kurulamıyor tekrar deneyiniz veya bu durumu yetkiliye bildiriniz | Hata Sebebi: " + ex.ToString(), "Hata", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

                if (result == DialogResult.Retry)
                {
                    Postrequest(GetPublicIpAddress());
                }
                if (result == DialogResult.Ignore || result == DialogResult.Cancel || result == DialogResult.No || result == DialogResult.Ignore)
                {
                    this.Close();
                }
            }
        }

        private void PostrequestDelete(string ipadress)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://000000.000.0000/JoinApi/Delete.php");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (WebClient client = new WebClient())
                {
                    client.UploadString(httpWebRequest.Address, ipadress);
                }
            }
            catch (WebException ex)
            {

                DialogResult result = MessageBox.Show("İşlemler esnasında bir hata oluştu, bağlantı kurulamıyor tekrar deneyiniz veya bu durumu yetkiliye bildiriniz | Hata Sebebi: " + ex.ToString(), "Hata", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

                if (result == DialogResult.Retry)
                {
                    Postrequest(GetPublicIpAddress());
                }
                if (result == DialogResult.Ignore || result == DialogResult.Cancel || result == DialogResult.No || result == DialogResult.Ignore)
                {
                    this.Close();
                }
            }
        }

        private void pictureSettings_Click(object sender, EventArgs e)
        {
            //panelSettings.Visible = true;
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            madness.kapatProgrami();
        }

        private void pictureCloseSettings_Click(object sender, EventArgs e)
        {
            //panelSettings.Visible = false;
        }

        private void hileKoruma_Tick(object sender, EventArgs e)
        {
            madness.hileDurdur();
        }

        private void btnCacheTemizleme_Click(object sender, EventArgs e)
        {
            //rp.cacheDelete();
        }

        private void btnGuncellemeDenetle_Click(object sender, EventArgs e)
        {
            madness.guncellemekontrolet();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void btnOyna_Click(object sender, EventArgs e)
        {
            hileKoruma.Enabled = true;
            System.Diagnostics.Process.Start($"fivem://connect/{Ip}:{Port}");
            Postrequest(GetPublicIpAddress());

        }

        private void lblBaslik_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void lblBaslik_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void lblBaslikYazisi_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            this.Hide();
            frm2.Show();

        }

        private void panelSettings_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblBaslik_Click(object sender, EventArgs e)
        {

        }

        private void labelCount_Click(object sender, EventArgs e)
        {

        }


        private void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            this.Hide();
            frm2.Show();
        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("ts3server://ıp");
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            this.Hide();
            frm2.Show();
        }
    }

    internal class labelCount
    {
        internal static string Text;
        internal static Color ForeColor;
    }
}
