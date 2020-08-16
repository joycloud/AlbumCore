using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AlbumCore.Models;
using System.IO;
using Microsoft.Extensions.Hosting;
using AlbumCore.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Http;
using System.Drawing;
using System.Drawing.Imaging;
using static AlbumCore.Models.selectModel;

namespace AlbumCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        private IHostEnvironment _hostingEnvironment;

        public HomeController(IHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult CreateAlbum()
        {
            return View();
        }

        public IActionResult AlbumView()
        {
            string path = _hostingEnvironment.ContentRootPath + "\\wwwroot\\Album\\";
            string[] dirs = Directory.GetDirectories(path); //目錄(含路徑)的陣列
            System.Collections.ArrayList dirlist = new System.Collections.ArrayList(); //用來儲存只有目錄名的集合          


            foreach (string item in dirs)
                dirlist.Add(Path.GetFileNameWithoutExtension(item)); //只取得目錄名稱(不含路徑)


            // get AlbumsList to order by
            var data = selectModel.AlbumListSelect();
            List<string> dirlist2 = new List<string>();

            
            foreach (var list in data)
            {
                foreach (var item in dirlist)
                {
                    // show pictures in AlbumListSelect
                    if (item.ToString() == list.albumname)
                        dirlist2.Add(list.albumname);
                }
            }


            string path1 = "";
            List<PicList> paths = new List<PicList>();

            foreach (var item in dirlist2)
            {
                path1 = _hostingEnvironment.ContentRootPath + "\\wwwroot\\Album\\" + item.ToString() + "\\smail\\";
                string[] filePaths = Directory.GetFiles(path1);

                if (filePaths.Length != 0)
                {
                    paths.Add(new PicList
                    {
                        path = filePaths[0].ToString(),
                        Albumname = item.ToString()
                    });
                }
            }

            ImgLibEntity lib = new ImgLibEntity();
            ViewBag.Libs = lib.ImageLibs(paths);
            return View();
        }


        public class PicList
        {
            public string path { get; set; }
            public string Albumname { get; set; }
        }


        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // Create Album
        [HttpPost]
        public string Albumname(string filename)
        {
            if (string.IsNullOrEmpty(filename))
                return "相簿名稱必填!!";

            // 建立資料夾名稱
            string datename = DateTime.Now.ToString("yyyyMMdd") + "_";
            filename = datename + filename;


            string path = _hostingEnvironment.ContentRootPath + "\\wwwroot\\Album\\" + filename;

            // 有存在且沒有關閉的相簿
            List<Album> Album_Select = selectModel.AlbumSelect(filename);

            if (Directory.Exists(path) && Album_Select.Count > 0)
                return "The filename has existed;" + filename;
            else
            {
                // create Album
                Directory.CreateDirectory(path);
                // create 大小圖的資料夾
                string Albumname_big = path + "//big";
                string Albumname_smail = path + "//smail";
                // 建大小圖資料夾
                Directory.CreateDirectory(Albumname_big);
                Directory.CreateDirectory(Albumname_smail);

                Album Album = new Album();
                Album.Name = filename;
                Album.Path = path;
                Album.sctrl = "Y";
                Album.eddate = DateTime.Now;
                Album.crdate = DateTime.Now;

                // Create Album into Datatable
                new crudModel().AlbumCreate(Album);
                return "Albumname Successed;" + filename;
            }
        }


        [HttpPost]
        public async Task<IActionResult> Pictures(string newfilename)
        {
            string path = _hostingEnvironment.ContentRootPath + "\\wwwroot\\Album\\" + newfilename;
            string Albumname_big = path + "\\big";
            string Albumname_smail = path + "\\smail";

            if (Request.Form.Files.Count == 0)
                return NotFound();

            // find the max SN
            int SN = selectModel.NewSN(newfilename);

            // 先save原圖
            foreach (var formFile in Request.Form.Files)
            {
                string path_big = Albumname_big + "\\" + formFile.FileName;
                string path_smail = Albumname_smail + "\\" + formFile.FileName;

                if (formFile.Length > 0)
                {
                    using (var stream = new FileStream(path_big, FileMode.Create))
                        await formFile.CopyToAsync(stream);
                }

                // 抓大圖壓縮成小圖==========================================================================                
                imageuse(path_big, path_smail, formFile.FileName);



                int idnum = selectModel.idnum(SN);
                AlbumPicture AlbumPicture = new AlbumPicture();
                AlbumPicture.Sn = SN;
                AlbumPicture.idnum = idnum;
                AlbumPicture.Picturefile = formFile.FileName;
                AlbumPicture.Path = path_big;
                AlbumPicture.sctrl = "Y";
                AlbumPicture.crdate = DateTime.Now;
                new crudModel().PictureCreate(AlbumPicture);

                #region
                //// 先save原圖
                //var fileContent = Request.Form.Files[file];
                //if (fileContent != null && fileContent.ContentLength > 0)
                //{
                //    // save原圖
                //    // 取得的檔案是stream
                //    var stream = fileContent.InputStream;
                //    var fileName = Path.GetFileName(file);
                //    //var path_big = Albumname_big + "//" + fileName.ToString();

                //    // 轉相對路徑
                //    string path_big = Albumname_big + "\\" + fileName.ToString();
                //    using (var fileStream = System.IO.File.Create(path_big))
                //        stream.CopyTo(fileStream);

                //    //int idnum = selectModel.idnum(SN);
                //    //AlbumPicture AlbumPicture = new AlbumPicture();
                //    //AlbumPicture.SN = SN;
                //    //AlbumPicture.idnum = idnum;
                //    //AlbumPicture.picturefile = fileName;
                //    //AlbumPicture.path = path_big;
                //    //AlbumPicture.sctrl = "N";
                //    //AlbumPicture.crdate = DateTime.Now;
                //    //new crudModel().PictureCreate(AlbumPicture);

                //    //如果有copy檔案的話要歸零
                //    stream.Position = 0;

                //    // 抓大圖壓縮成小圖==========================================================================
                //    //string path_smail = Albumname_smail + "\\" + fileName.ToString());
                //    //imageuse(path_big, path_smail, fileName.ToString());
                //}
                #endregion
            }
            return Ok(new { mes = "Successed" });
        }

        private void imageuse(string path_big, string path_smail, string fileName)
        {
            // 不要宣告Bitmap，因為屬性Server.MapPath無法存外部
            Image img = Image.FromFile(path_big);
            // 長寬
            int width = 0;
            int height = 0;


            if (img.Width < 400 && img.Height < 400)
            {
                //width = 300 / height * img.Width;
                //height = 300;
                width = img.Width;
                height = img.Height;
            }
            else
            {
                if (img.Width > img.Height)
                {
                    //width = 300 / height * img.Width;
                    //height = 300;
                    width = 400;
                    height = img.Height / (img.Width / width);
                }
                else if (img.Width < img.Height)
                {
                    //width = 300 / height * img.Width;
                    //height = 300;
                    height = 400;
                    width = img.Width / (img.Height / height);
                }
                else
                {
                    width = 300;
                    height = 300;
                }
            }

            Image imgNew = new Bitmap(width, height);
            // 宣告繪圖UI
            Graphics g = Graphics.FromImage(imgNew);
            // 壓縮
            g.DrawImage(img, new System.Drawing.Rectangle(0, 0, width, height),
            new System.Drawing.Rectangle(0, 0, img.Width, img.Height),
            System.Drawing.GraphicsUnit.Pixel);

            // Image可存外部
            imgNew.Save(path_smail, ImageFormat.Jpeg);
            //idnum++;
        }

        public ActionResult ShowPics(string bigPath)
        {
            ViewBag.pic = bigPath;
            return View();
        }

        public IActionResult PicsView()
        {
            return View();
        }

        [HttpGet]
        public IActionResult PicsView(string Albumname)
        {
            if (string.IsNullOrEmpty(Albumname))
                Albumname = "20200809_ssss";

            string path = _hostingEnvironment.ContentRootPath + "\\wwwroot\\Album\\" + Albumname + "\\smail\\";
            string[] filePaths = Directory.GetFiles(path);
            List<PicList> List = new List<PicList>();


            // get top 20 pictures list
            //List<picstopList> toplist = selectModel.picstop(Albumname,1);


            // get top 20 pictures list orderby idnum
            var PicsList = selectModel.PicsSelect(Albumname, 1);

            foreach (var list in PicsList)
            {
                foreach (string item in filePaths)
                {
                    int i = item.IndexOf("smail\\") + 6;
                    string stringname = item.Substring(i , item.Length - i);

                    // show pictures in PicsList
                    if (stringname == list.picturename)
                        List.Add(new PicList { path = item.ToString(), Albumname = "" });
                }
            }

            ImgLibEntity lib = new ImgLibEntity();
            ViewBag.Pics = lib.ImageLibs(List);
            return View();
        }
    }
}
