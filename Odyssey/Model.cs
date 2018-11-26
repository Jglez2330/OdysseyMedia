using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odyssey
{
    public class Model
    {
        private string videoBytes;
        private Metadata videoMetadata;
        private JsonManagement jsonManagement = new JsonManagement();
        private Controller controller;

        public void SetController(Controller pController)
        {
            this.controller = pController;
        }


        public void SetVideoBytes(string videoPath)
        {
            this.videoBytes = UploadVideoBytes(videoPath);
        }

        public string UploadVideoBytes(string videoPath)
        {
            byte[] bytes = System.IO.File.ReadAllBytes(videoPath);
            string bytesToString = Convert.ToBase64String(bytes);
            return bytesToString;

        }

        public void CreateMetadata(string name, string director, string duration, string description, string date)
        {
            this.videoMetadata = new Metadata { Name = name, Director = director, Duration = duration, Description = description, Date = date };
        }

        public void UploadVideoRequest()
        {
            string jsonUpload = jsonManagement.JsonSerialization0(this.videoBytes, this.videoMetadata);
            Console.WriteLine(jsonUpload);
            UploadVideoResponse(true);
            //Mando al socket jsonUpload
        }

        public void UploadVideoResponse(bool confirmation)
        {
            if (confirmation)
            {
                Console.WriteLine("The video was uploaded");
                controller.confirmUpload();
            }
            else
            {
                Console.WriteLine("The video could not be uploaded");
                controller.deniedUpload();
            }
        }

        public void PlayVideoRequest(string videoName)
        {
            string jsonPlay = jsonManagement.JsonSerialization1(videoName);
            //Mando al socket jsonPlay
        }

        public void PlayVideoResponse(string jsonPlayResponse)
        {
            if (jsonPlayResponse == "")
            {
                //Mando al controller a indicar que no se pudo obtener el video
                Console.WriteLine("Can not play video");
            }
            else
            {
                this.videoBytes = jsonManagement.JsonDeserialization1(jsonPlayResponse);
                byte[] bytes = Convert.FromBase64String(this.videoBytes);
                //Mando el byte[] o convierto a mp4 y mando al controller para reproducción
            }


        }

        public void UpdateVideoMetadataRequest()
        {
            string jsonUpdate = jsonManagement.JsonSerialization2(this.videoMetadata);
            //Mando al socket jsonUpdate
        }

        public void UpdateVideoMetadataResponse(bool confirmation)
        {
            if (confirmation)
            {
                //Mando al controller mensaje de confirmación
            }
            else
            {
                Console.WriteLine("The metadata could not be updated");
                //Ordeno al controller mostrar mensaje de error
            }
        }


        public void DeleteVideoRequest(string videoName)
        {
            string jsonDelete = jsonManagement.JsonSerialization3(videoName);
            //Mando al socket jsonDelete
        }

        public void DeleteVideoResponse(bool confirmation)
        {
            if (confirmation)
            {
                //Ordeno al controller eliminar de pantalla el video this.deleteVideoID
            }
            else
            {
                Console.WriteLine("The video could not be deleted");
                //Ordeno al controller mostrar mensaje de error
            }
        }


    }
}
