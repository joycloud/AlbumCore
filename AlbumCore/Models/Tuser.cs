using System;
using System.Collections.Generic;

namespace AlbumCore.Models
{
    public partial class Tuser
    {
        public int Id { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public string Village { get; set; }
        public string Address { get; set; }
    }
}
