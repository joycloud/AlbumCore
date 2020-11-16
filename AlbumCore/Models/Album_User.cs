using System;
using System.Collections.Generic;

namespace AlbumCore.Models
{
    public partial class Album_User
    {
        public int ID { get; set; }
        public string account { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public int lev { get; set; }
        public string type { get; set; }
        public string open { get; set; }
        public string Third { get; set; }
        public string ThirdID { get; set; }
        public DateTime createdate { get; set; }
        public DateTime editdate { get; set; }
        public DateTime logintime { get; set; }
    }
}
