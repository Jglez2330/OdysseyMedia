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
            controller.setMetadata(textBox2.Text,textBox3.Text,textBox4.Text,textBox5.Text,textBox1.Text);
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.sng = Form1.Temp_song;
        }
    }
}
