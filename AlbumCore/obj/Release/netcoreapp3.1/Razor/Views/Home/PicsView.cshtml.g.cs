#pragma checksum "C:\Users\b2551\OneDrive\桌面\MyGitKraken\AlbumCore\AlbumCore\Views\Home\PicsView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3a8e3721f8bf7edee0147f370a75d9ff168030f2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_PicsView), @"mvc.1.0.view", @"/Views/Home/PicsView.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\b2551\OneDrive\桌面\MyGitKraken\AlbumCore\AlbumCore\Views\_ViewImports.cshtml"
using AlbumCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\b2551\OneDrive\桌面\MyGitKraken\AlbumCore\AlbumCore\Views\_ViewImports.cshtml"
using AlbumCore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3a8e3721f8bf7edee0147f370a75d9ff168030f2", @"/Views/Home/PicsView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9a121c494f2cd7e9e2c70a3c32b2f1c584f56bd0", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_PicsView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\b2551\OneDrive\桌面\MyGitKraken\AlbumCore\AlbumCore\Views\Home\PicsView.cshtml"
  
    ViewData["Title"] = "PicsView";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Pictures View</h1>

<style>
    #gotop {
        position: fixed;
        border-radius: 50px;
        right: 20px;
        bottom: 30px;
        padding: 2px 13px;
        font-size: 25px;
        background: rgba(228, 211, 211, 0.36);
        color: #FAFCFD;
        cursor: pointer;
        z-index: 1000;
    }
   
</style>
    <div class=""feed"">
        <div id=""art1"" class=""article"">
            <ul id=""aniimated-thumbnials"" class=""list-unstyled row"">
");
#nullable restore
#line 27 "C:\Users\b2551\OneDrive\桌面\MyGitKraken\AlbumCore\AlbumCore\Views\Home\PicsView.cshtml"
                  
                    foreach (var image in ViewBag.Pics)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li class=\"picts\" data-src=");
#nullable restore
#line 30 "C:\Users\b2551\OneDrive\桌面\MyGitKraken\AlbumCore\AlbumCore\Views\Home\PicsView.cshtml"
                                              Write(Url.Content(image.bigPath));

#line default
#line hidden
#nullable disable
            WriteLiteral(" data-pinterest-text=\"Pin it1\" data-tweet-text=\"share on twitter 1\">\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 857, "\"", 864, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                <img class=\"img-responsive\"");
            BeginWriteAttribute("src", " src=", 927, "", 958, 1);
#nullable restore
#line 32 "C:\Users\b2551\OneDrive\桌面\MyGitKraken\AlbumCore\AlbumCore\Views\Home\PicsView.cshtml"
WriteAttributeValue("", 932, Url.Content(image.smPath), 932, 26, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Thumb-1\">\r\n                            </a>\r\n                        </li>\r\n");
#nullable restore
#line 35 "C:\Users\b2551\OneDrive\桌面\MyGitKraken\AlbumCore\AlbumCore\Views\Home\PicsView.cshtml"
                    }
                

#line default
#line hidden
#nullable disable
            WriteLiteral("            </ul>\r\n        </div>\r\n    </div>\r\n    <div id=\"gotop\">⇧</div>\r\n\r\n<script>\r\n");
            WriteLiteral(@"    lightGallery(document.getElementById('aniimated-thumbnials'), {
        thumbnail: true
    });

    // back to top
    // onload to hide the button
    window.onload = function () {
        $('#gotop').stop().fadeOut(""fast"");
    }

    // click and back to top
    $(""#gotop"").click(function () {
        $(""html,body"").animate({
            scrollTop: 0
        }, 1000);
    });
    // if < 300 hide else show
    $(window).scroll(function () {
        if ($(this).scrollTop() > 300) {
            $('#gotop').fadeIn(""fast"");
        } else {
            $('#gotop').stop().fadeOut(""fast"");
        }
    });

    // Scroll to find the others pictures
    $(document).ready(function () {
        $('.feed').infiniteScroll({
            path: function () {
                // 刪除空白內容div
                var thisNode = document.getElementById(""art0"");
                if (thisNode != null)
                    thisNode.remove();
                if (this.loadCount < ");
#nullable restore
#line 90 "C:\Users\b2551\OneDrive\桌面\MyGitKraken\AlbumCore\AlbumCore\Views\Home\PicsView.cshtml"
                                Write(ViewBag.totalpage);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ) {\r\n                    return \"/Home/TemporaryView?num=\" + this.loadCount + \"&Albumname=\" + \'");
#nullable restore
#line 91 "C:\Users\b2551\OneDrive\桌面\MyGitKraken\AlbumCore\AlbumCore\Views\Home\PicsView.cshtml"
                                                                                     Write(ViewBag.Albumname);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"'; // 讀取此頁面
                }
            },
            append: '.article',
            status: '.scroller-status',
        });
    });

    //$(document).ready(function () {
    //    var we = $('.container2').width();
    //    console.log(we);
    //});

    //$(document).ready(function () {
    //    $(window).resize(function () {
    //        $(""span"").text(x += 1);
    //    });

</script>
");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
