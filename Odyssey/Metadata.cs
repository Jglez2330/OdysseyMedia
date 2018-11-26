using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odyssey
{
    class Metadata
    {

        public string Name { get; set; }
        public string Director { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }

        public string GetName()
        {
            return this.Name;
        }

        public string GetDirector()
        {
            return this.Director;
        }

        public string GetDuration()
        {
            return this.Duration;
        }

        public string GetDescription()
        {
            return this.Description;
        }

        public string GetDate()
        {
            return this.Date;
        }

    }
}
