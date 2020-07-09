using System;
using System.Collections.Generic;

namespace AlbumCore.Models
{
    public partial class BudgetBugda
    {
        public string Bugda { get; set; }
        public int Total { get; set; }
        public Guid Puid { get; set; }
        public Guid Uid { get; set; }
    }
}
