using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odyssey
{
    public class Controller
    {
        private Model model;
        private Form1 form1;

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
    }
}
