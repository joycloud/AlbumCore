using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static AlbumCore.Controllers.HomeController;

namespace AlbumCore.Entities
{
    public class ImgLibEntity
    {
        public class ImgLib
        {
            public string Filename { get; set; }
            public string smPath { get; set; }
            public string bigPath { get; set; }
            public string PathUrl { get; set; }
            public string Albumname { get; set; }
        }

        public List<ImgLib> ImageLibs(List<PicList> paths)
        {
            List<ImgLib> List = new List<ImgLib>();
            foreach (var item in paths)
            {
                int i = item.path.IndexOf("\\Album\\");
                string finpath = "~" + item.path.Substring(i, item.path.Length - i);
                finpath = finpath.Replace("\\", "/");

                // Album URL
                string Url = "PicsView?Albumname=" + item.Albumname;

                string[] sArray = item.ToString().Split('\\');
                int count = sArray.Count();

                List.Add(new ImgLib { Filename = sArray[count - 1].ToString(), smPath = finpath, bigPath = finpath.Replace("smail","big"), PathUrl = Url, Albumname = item.Albumname });
            }

            return List;
        }      
    }
}
