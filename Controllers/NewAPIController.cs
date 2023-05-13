using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using JengApp.Models;

namespace JengApp.Controllers
{
    [Route("/api/[controller]/[action]")]
    public class NewAPIController : ControllerBase
    {

        private readonly prelimcrudContext _context;

        public NewAPIController(prelimcrudContext context)
        {
            _context = context;
        }

        public ActionResult<List<Product>> getAllProduct()
        {
            return _context.Products.ToList();
        }
        
    }
}
