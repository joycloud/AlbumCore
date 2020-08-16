using System;
using System.Collections.Generic;

namespace AlbumCore.Models
{
    public partial class AlbumPicture
    {
        public int Sn { get; set; }
        public int idnum { get; set; }
        public string sctrl { get; set; }
        public string Path { get; set; }
        public string Picturefile { get; set; }
        public string Remark { get; set; }
        public string cruser { get; set; }
        public DateTime? crdate { get; set; }
        public string eduser { get; set; }
        public DateTime? eddate { get; set; }
    }
}
