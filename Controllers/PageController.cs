using Microsoft.AspNetCore.Mvc;
using JengApp.Models;

namespace sampleMVC.Controllers
{
    public class PageController : Controller
    {
       
        public ActionResult Product(){
            return View();
        }


        public ActionResult ProductList(){
            return View();
        }


    }
}