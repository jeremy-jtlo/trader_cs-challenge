using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.WebEncoders;

namespace MvcMovie.Controllers 
{
    public class PictureController : Controller
    {
        //
        // GET: /Picture/
        public string Index() 
        {
            return "This is my default action. Hurr durr";
        }
        
        //
        // GET: /Picture/Welcome/
        public string Welcome() {
            return "Here's the welcome action method.";
        }
    }
}