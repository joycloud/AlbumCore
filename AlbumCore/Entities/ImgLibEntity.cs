using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbumCore.Entities
{
    public class ImgLibEntity
    {
        public class ImgLib
        {
            public string Filename { get; set; }
            public string smPath { get; set; }
            public string bigPath { get; set; }
        }

        public List<ImgLib> ImageLibs(List<String> paths)
        {

            List<ImgLib> List = new List<ImgLib>();
            foreach (var item in paths)
            {
                int i = item.IndexOf("\\Album\\");
                string finpath = "~" + item.Substring(i, item.Length - i);
                finpath = finpath.Replace("\\","/");

                string[] sArray = item.ToString().Split('\\');
                int count = sArray.Count();
                List.Add(new ImgLib { Filename = sArray[count - 1].ToString(), smPath = finpath, bigPath = finpath.Replace("smail", "big") });
            }

            return List;
        }
    }
}
