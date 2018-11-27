using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odyssey
{
    class JsonManagement
    {

        public string JsonSerialization0(string videoBytes, Metadata videoMetadata)
        {
            dynamic uploadObject = new ExpandoObject();
            uploadObject.Opcode = 0;
            uploadObject.VideoBytes = videoBytes;
            uploadObject.Name = videoMetadata.GetName();
            uploadObject.Director = videoMetadata.GetDirector();
            uploadObject.Duration = videoMetadata.GetDuration();
            uploadObject.Description = videoMetadata.GetDescription();
            uploadObject.Date = videoMetadata.GetDate();
            string result0 = JsonConvert.SerializeObject(uploadObject);
            return result0;
        }

        public string JsonSerialization1(string videoName)
        {
            dynamic playObject = new ExpandoObject();
            playObject.Opcode = 1;
            playObject.VideoName = videoName;
            string result1 = JsonConvert.SerializeObject(playObject);
            return result1;
        }

        public string JsonDeserialization1(string jsonPlayResponse)
        {
            var jsonPlayObject = JsonConvert.DeserializeObject<dynamic>(jsonPlayResponse);
            string videoBytes = jsonPlayObject.VideoBytes;
            return videoBytes;
        }

        public string JsonSerialization2(Metadata videoMetadata)
        {
            dynamic updateObject = new ExpandoObject();
            updateObject.Opcode = 2;
            updateObject.Name = videoMetadata.GetName();
            updateObject.Director = videoMetadata.GetDirector();
            updateObject.Duration = videoMetadata.GetDuration();
            updateObject.Description = videoMetadata.GetDescription();
            updateObject.Date = videoMetadata.GetDate();
            string result2 = JsonConvert.SerializeObject(updateObject);
            return result2;
        }

        public string JsonSerialization3(string videoName)
        {
            dynamic deleteObject = new ExpandoObject();
            deleteObject.Opcode = 3;
            deleteObject.VideoName = videoName;
            string result3 = JsonConvert.SerializeObject(deleteObject);
            return result3;
        }

        public bool JsonDeserialization(string jsonResponse)
        {
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonResponse);
            bool confirmation = jsonObject.Bool;
            return confirmation;
        }

    }
}
