﻿using System;
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
    public partial class Form1 : Form
    {

        Boolean size=true;
        List<Song> songs = new List<Song>();
        private static Song temp_song;
        private Controller controller;

        internal static Song Temp_song { get => temp_song; set => temp_song = value; }

        public Form1()
        {
            InitializeComponent();
            
        }

        public void SetController(Controller pController)
        {
            this.controller = pController;
        }

        private void bunifuImageButton8_Click(object sender, EventArgs e)
        {
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Select_Video_Click(object sender, EventArgs e)
        {
            int temp = lstSongs.SelectedIndex;
            lstSongs.Items.RemoveAt(temp);
            songs.RemoveAt(temp);
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            
            this.media.Ctlcontrols.play();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            this.media.Ctlcontrols.pause();
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            this.media.Ctlcontrols.fastForward();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            this.media.Ctlcontrols.fastReverse();
        }

        private void bunifuImageButton8_Click_1(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void bunifuImageButton7_Click(object sender, EventArgs e)
        {
            if (size)
            {
                this.WindowState = FormWindowState.Maximized;
                size = false;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                size = true;
            }
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuSlider2_ValueChanged(object sender, EventArgs e)
        {
            this.media.settings.volume = this.bunifuSlider2.Value;

        }

        private void bunifuSlider1_ValueChanged(object sender, EventArgs e)
        {
            this.media.Ctlcontrols.currentPosition = (int)((this.media.currentMedia.duration)/100)*(this.bunifuSlider1.Value);
        }
        

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            temp_song=songs[lstSongs.SelectedIndex];
            Form2 f2 = new Form2();
            f2.ShowDialog();
            lstSongs.Items[lstSongs.SelectedIndex] = temp_song.get_name();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog opn = new OpenFileDialog();
            temp_song = new Song();
            if (opn.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                temp_song.set_path(opn.FileName);
                controller.setVideoBytes(opn.FileName);
                Form2 f2 = new Form2();
                f2.SetController(this.controller);
                f2.ShowDialog();
                controller.uploadVideo();

            }

            
        }

        public void confirmUpload()
        {
            MessageBox.Show("The video was successfully uploaded");
            lstSongs.Items.Add(temp_song.get_name());
            songs.Add(temp_song);
        }

        public void deniedUpload()
        {
            MessageBox.Show("The video could not be uploaded");
        }
        

        private void lstSongs_SelectedIndexChanged(object sender, EventArgs e)
        {

            //Console.WriteLine(lstSongs.GetItemText(lstSongs.SelectedItem));
            //this.media.URL = songs[(lstSongs.SelectedIndex)].get_path();

        }

        private void lstSongs_DoubleClick(object sender, EventArgs e)
        {
            this.media.URL = songs[(lstSongs.SelectedIndex)].get_path();
            //Debug.WriteLine("DoubleClick event fired on ListBox");
        }



    }

}
