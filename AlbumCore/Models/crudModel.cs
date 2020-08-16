using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AlbumCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace AlbumCore.Models
{
    public class crudModel : Controller
    {
        public void AlbumCreate(Album Album)
        {
            using (MISContext db = new MISContext())
            {
                db.Album.Add(Album);
                db.SaveChanges();
            }
        }
        public void PictureCreate(AlbumPicture AlbumPicture)
        {
            using (MISContext db = new MISContext())
            {
                db.AlbumPicture.Add(AlbumPicture);
                db.SaveChanges();
            }
        }
    }
}
