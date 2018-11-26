using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Odyssey
{
    public partial class Form2 : Form
    {
        Song sng;
        private Controller controller;
        private bool upload;
        private bool metadata;

        public void setMetadata(bool flag)
        {
            metadata = flag;
        }

        public void setBool(bool flag)
        {
            upload = flag;
        }

        public void SetController(Controller pController)
        {
            this.controller = pController;
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            sng.set_date(textBox1.Text);
            sng.set_name(textBox2.Text);
            sng.set_director(textBox3.Text);
            sng.set_time(textBox4.Text);
            sng.set_description(textBox5.Text);
            
            if (upload)
            {
                controller.setMetadata(textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox1.Text);
                controller.uploadVideo();
            }
            else if (metadata)
            {
                controller.setMetadata(textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox1.Text);
                controller.updateMetadata();
            }
            upload = false;
            metadata = false;
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.sng = Form1.Temp_song;
            textBox1.Text = sng.get_date();
            textBox2.Text = sng.get_name();
            textBox3.Text = sng.get_director();
            textBox4.Text = sng.get_time();
            textBox5.Text = sng.get_description();
        }
    }
}
