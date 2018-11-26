using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odyssey
{
    class Song
    {
        string path;
        string name;
        string director;
        string description;
        string date;
        string time;

   
        public string get_path()
        {
            return this.path;
        }
        public string get_name()
        {
            return this.name;
        }
        public string get_director()
        {
            return this.director;
        }
        public string get_description()
        {
            return this.description;
        }
        public string get_date()
        {
            return this.date;
        }
        public string get_time()
        {
            return this.time;
        }
        public void set_path(string path)
        {
            this.path = path;
        }
        public void set_name(string name)
        {
            this.name = name;
        }
        public void set_director(string director)
        {
            this.director = director;
        }
        public void set_description(string description)
        {
            this.description = description;
        }
        public void set_date(string date)
        {
            this.date = date;
        }
        public void set_time(string time)
        {
            this.time = time;
        }
    }
}
