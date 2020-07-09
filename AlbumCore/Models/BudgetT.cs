using System;
using System.Collections.Generic;

namespace AlbumCore.Models
{
    public partial class BudgetT
    {
        public string Bno { get; set; }
        public string Month { get; set; }
        public int? Total { get; set; }
        public Guid? Uid { get; set; }
        public string Dept { get; set; }
        public string Sctrl { get; set; }
        public int? Lev { get; set; }
    }
}
