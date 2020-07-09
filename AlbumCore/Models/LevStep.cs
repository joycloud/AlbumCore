using System;
using System.Collections.Generic;

namespace AlbumCore.Models
{
    public partial class LevStep
    {
        public string Bno { get; set; }
        public string System { get; set; }
        public string Type { get; set; }
        public decimal Lev { get; set; }
        public string Sign { get; set; }
        public string Sctrl { get; set; }
        public string Cruser { get; set; }
        public DateTime? Crdate { get; set; }
        public string Eduser { get; set; }
        public DateTime? Eddate { get; set; }
    }
}
