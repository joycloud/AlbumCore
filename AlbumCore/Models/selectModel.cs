using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using AlbumCore.Models;
using Microsoft.EntityFrameworkCore;

namespace AlbumCore.Models
{
    public class selectModel
    {

        public static List<Album> AlbumSelect(string filename)
        {
            using (MISContext db = new MISContext())
            {
                //var data = db.Album.Where(s =>  s.sctrl == "Y").ToList();
                var data = db.Album.Where(s => s.Name == filename && s.sctrl == "Y").ToList();
                return data;
            }
        }
        // get AlbumList
        public static List<AlbumList> AlbumListSelect()
        {
            using (MISContext db = new MISContext())
            {
                var data = db.Album.Where(s => s.sctrl == "Y").Select(o =>
                new AlbumList { albumname = o.Name, crdate = o.crdate }).
                OrderByDescending(o => o.crdate).ToList();

                return data;
            }
        }
        public partial class AlbumList
        {
            public string albumname { get; set; }
            public DateTime crdate { get; set; }
        }

        // get PicturesList
        public static List<PicsList> PicsSelect(string Albumname, int idnum)
        {
            using (MISContext db = new MISContext())
            {
                var data = (from a in db.AlbumPicture
                            join b in db.Album on a.Sn equals b.SN
                            where b.Name == Albumname && a.sctrl == "Y" && a.idnum >= idnum
                            orderby (a.idnum)
                            select new PicsList
                            {
                                picturename = a.Picturefile,
                                idnum = a.idnum
                            }).Take(20).ToList();

                return data;
            }
        }

        public partial class PicsList
        {
            public string picturename { get; set; }
            public int idnum { get; set; }
        }

        // 取最新SNid
        public static int NewSN(string newfilename)
        {
            using (MISContext db = new MISContext())
            {
                int SN = 1;
                if (db.Album.Where(o => o.Name == newfilename).Count() > 0)
                    SN = db.Album.Where(o => o.Name == newfilename && o.sctrl == "Y").OrderByDescending(o => o.crdate).Select(s => s.SN).FirstOrDefault();
                return SN;
            }
        }

        public static int idnum(int SN)
        {
            using (MISContext db = new MISContext())
            {
                int num = 1;
                if (db.AlbumPicture.Where(o => o.Sn == SN).Select(o => o.idnum).Count() > 0)
                    num = db.AlbumPicture.Where(o => o.Sn == SN).Select(o => o.idnum).Max() + 1;
                return num;
            }
        }

        // loading and get top 20 pictures
        public static List<picstopList> picstop(string Albumname,int idnum)
        {
            using (MISContext db = new MISContext())
            {
                int SN = db.Album.Where(s => s.Name == Albumname).Select(s => s.SN).ToList()[0];
                
                var data = (from o in db.AlbumPicture                             
                            where o.sctrl == "Y" && o.Sn == SN && o.idnum >= idnum
                            orderby (o.idnum)
                            select new picstopList
                            {
                                idnum = o.idnum,
                                Picturefile = o.Picturefile                                
                            }).Take(20).ToList();

                return data;
            }
        }

        public partial class picstopList
        {
            public int idnum { get; set; }
            public string Picturefile { get; set; }         
        }
    }
}

