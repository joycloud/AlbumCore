using System;
using System.Collections.Generic;

namespace AlbumCore.Models
{
    public partial class Dept
    {
        public string DeptNo { get; set; }
        public string Name { get; set; }
        public string Sctrl { get; set; }
        public int? Gpdept { get; set; }
        public string Supervisor { get; set; }
        public string Agent { get; set; }
    }
}
