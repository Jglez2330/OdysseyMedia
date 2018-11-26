using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odyssey
{
    public class Controller
    {
        private Model model;
        private Form1 form1;
        private string temp_name;

        public void SetModel(Model pModel)
        {
            this.model = pModel;
        }

        public void SetForm1(Form1 pForm1)
        {
            this.form1 = pForm1;
        }


        public void setVideoBytes(string videoPath)
        {
            model.SetVideoBytes(videoPath);
        }

        public void setMetadata(string name, string director, string duration, string description, string date)
        {
            model.CreateMetadata(name, director, duration, description, date);
        }

        public void uploadVideo()
        {
            model.UploadVideoRequest();
        }

        public void confirmUpload()
        {
            form1.confirmUpload();
        }

        public void deniedUpload()
        {
            form1.deniedUpload();
        }

        public void playVideo(string videoName)
        {
            temp_name = videoName;
            model.PlayVideoRequest(videoName);
        }

        public void playDenied()
        {
            form1.playDenied();
        }

        public void playConfirm (byte[] bytes)
        {
            string videoPath = "C:/Users/Fabricio/Desktop" + "/Videos" + "/" + temp_name + ".mp4";

            if(!File.Exists(videoPath))
            {
                File.WriteAllBytes(videoPath, bytes);
                form1.playConfirm(videoPath);
            }
            else
            {
                form1.playConfirm(videoPath);
            }

        }

        public void updateMetadata ()
        {
            model.UpdateVideoMetadataRequest();
        }

        public void updateMetadataSucces ()
        {
            form1.updateMetadataSucces();
        }

        public void deleteVideo(string videoName)
        {
            model.DeleteVideoRequest(videoName);
        }

        public void deleteSuccess()
        {
            form1.deleteSuccess();
        }

        public void deleteFail()
        {
            form1.deleteFail();
        }

    }
}
