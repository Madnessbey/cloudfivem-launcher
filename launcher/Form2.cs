using madnesslauncher;
using MaintenanceDiscordRPC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Policy;

namespace BasicLuancher
{
    public partial class Form2 : Form
    {
        private Point lastPoint;
        ayarlar rp = new ayarlar();
        private object client;

        public Form2()
        {
            InitializeComponent();
            this.BackColor = Color.DarkRed;
            this.TransparencyKey = Color.DarkRed;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //lblDuyuruMetni.Text = rp.duyurular;
            Rpc.SetupRpc();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            this.Hide();
            frm1.Show();
        }

        private void lblDuyuruMetni_Click(object sender, EventArgs e)
        {

        }

        private void lblBaslik_Click(object sender, EventArgs e)
        {
        }

        private void lblBaslik_Click_1(object sender, EventArgs e)
        {

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

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            rp.zipIndir("", "");
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            this.Hide();
            frm1.Show();
                
        }
    }

    internal class wc
    {
        internal static void DownloadFile(object url, string v)
        {
            throw new NotImplementedException();
        }
    }
}
    