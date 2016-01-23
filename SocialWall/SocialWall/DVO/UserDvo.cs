using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialWall.DVO
{
    public class UserDvo
    {
        public Cover cover { get; set; }
        public List<Device> devices { get; set; }
        public string first_name { get; set; }
        public string gender { get; set; }       
        public bool installed { get; set; }      
        public string last_name { get; set; }
        public string link { get; set; }       
        public Location location { get; set; }
        public string id { get; set; }

    }

    public class Cover
    {
        public string id { get; set; }
        public int offset_y { get; set; }
        public string source { get; set; }
    }

    public class Data
    {
        public bool is_silhouette { get; set; }
        public string url { get; set; }
    }

    public class Picture
    {
        public Data data { get; set; }
    }
    public class Device
    {
        public string hardware { get; set; }
        public string os { get; set; }
    }

    public class Location
    {
        public string id { get; set; }
        public string name { get; set; }
    }
}
