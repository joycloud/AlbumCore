using System;
using System.Collections.Generic;

namespace AlbumCore.Models
{
    public partial class Album
    {
        public int SN { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Permission { get; set; }
        public string Path { get; set; }
        public string download { get; set; }
        public string sctrl { get; internal set; }
        public string remark { get; set; }
        public string cruser { get; set; }
        public DateTime crdate { get; set; }
        public string eduser { get; set; }
        public DateTime eddate { get; set; }
    }
}
