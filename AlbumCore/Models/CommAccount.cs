﻿using System;
using System.Collections.Generic;

namespace AlbumCore.Models
{
    public partial class CommAccount
    {
        public int Sn { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public string Password { get; set; }
        public int? Permission { get; set; }
    }
}
