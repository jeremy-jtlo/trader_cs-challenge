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

        private Image ScaleImage(double scaleRatio)
        {
            var imageFile = OpenImage();

            double newWidth = imageFile.Width * scaleRatio;
            double newHeight = imageFile.Height * scaleRatio;

            var returnImage = (Image) imageFile.Clone();

            imageFile.Dispose();

            return returnImage;
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

        public FileResult DownloadFile()
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(ImagePath());
            string fileName = "bmw.jpg";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet,fileName);
        }

        public IActionResult ShrinkImage()
        {
            var shrunkenImage = ScaleImage(0.8);

            if (System.IO.File.Exists(ImagePath()))
            {
                System.IO.File.Delete(ImagePath());
            }

            shrunkenImage.Save(ImagePath());

            return Redirect("/Picture");
        }

        public IActionResult GrowImage()
        {
            var grownImage = ScaleImage(1.2);

            if (System.IO.File.Exists(ImagePath()))
            {
                System.IO.File.Delete(ImagePath());
            }

            grownImage.Save(ImagePath());

            return Redirect("/Picture");
        }

        public IActionResult RotateLeft()
        {
            var imageFile = OpenImage();

            imageFile.RotateFlip(RotateFlipType.Rotate270FlipNone);

            if (System.IO.File.Exists(ImagePath()))
            {
                System.IO.File.Delete(ImagePath());
            }
            imageFile.Save(ImagePath());

            imageFile.Dispose();
            return Redirect("/Picture");
        }

        public IActionResult RotateRight()
        {
            var imageFile = OpenImage();

            imageFile.RotateFlip(RotateFlipType.Rotate90FlipNone);

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
