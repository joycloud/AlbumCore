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

        public IActionResult AlbumView()
        {
            string path = _hostingEnvironment.ContentRootPath + "\\wwwroot\\Album\\";
            string[] dirs = Directory.GetDirectories(path); //目錄(含路徑)的陣列
            System.Collections.ArrayList dirlist = new System.Collections.ArrayList(); //用來儲存只有目錄名的集合          

            foreach (string item in dirs)
            {
                dirlist.Add(Path.GetFileNameWithoutExtension(item)); //只取得目錄名稱(不含路徑)
            }


            //System.Drawing.Image MyImage = null;
            string path1 = "";

            List<String> paths = new List<string>();

            foreach (var item in dirlist)
            {
                path1 = _hostingEnvironment.ContentRootPath + "\\wwwroot\\Album\\" + item.ToString() + "\\smail\\";
                //path = Server.MapPath("~/Album/" + item.ToString() + "/smail/");
                string[] filePaths = Directory.GetFiles(path1);
                paths.Add(filePaths[0].ToString());
            }

            ImgLibEntity lib = new ImgLibEntity();
            ViewBag.Libs = lib.ImageLibs(paths);
            return View();
        }

        //public void Configure(IApplicationBuilder app)
        //{
        //    // some middlewares
        //    app.UseStaticFiles();

        //    app.UseStaticFiles(new StaticFileOptions
        //    {
        //        FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Album")),
        //        RequestPath = "/Album"
        //    });
        //    // some other middlewares
        //}



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

        
    }
}
