using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace code_challenge.Controllers
{
    public class PictureController : Controller
    {
        // We're gonna be opening our bmw picture a couple times.
        // The private functions will come in handy every time we do it.
        private string ImagePath()
        {
            var currentPath = Directory.GetCurrentDirectory();
            var fileName = Path.Combine(currentPath, "wwwroot\\images\\bmw.jpg");
            return fileName;
        }
        private Image OpenImage()
        {
            var imageName = ImagePath();
            using (Image returnImage = Image.FromFile(imageName))
            {
                return returnImage;
            }
                
        }
        // GET: /Picture/
        public IActionResult Index()
        {
            ViewData["debugString"] = ImagePath();
            return View();
        }

        // Helper function to fetch images
        /*
        public ActionResult GetImage()
        {
            var imageFile = OpenImage();

            using (var streak = new MemoryStream())
            {
                imageFile.Save(streak, ImageFormat.Jpeg);
                return File(streak.ToArray(), "image/jpeg");
            }
        }
        */

        public IActionResult RotateRight()
        {
            var imageFile = OpenImage();

            if (System.IO.File.Exists(ImagePath()))
            {
                System.IO.File.Delete(ImagePath());
            }
            imageFile.Save(ImagePath());

            imageFile.Dispose();
            return Redirect("/Picture");
        }
    }
}
