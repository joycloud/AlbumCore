using System;
using System.Collections.Generic;

namespace AlbumCore.Models
{
    public partial class Process
    {
        public string System { get; set; }
        public string Type { get; set; }
        public decimal Lev { get; set; }
        public string Sign { get; set; }
        public string Sctrl { get; set; }
    }
}
