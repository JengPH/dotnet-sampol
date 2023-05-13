using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using JengApp.Models;
using JengApp.ViewModel;

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


        public ActionResult<List<Category>> getAllCategories(){
            return _context.Categories.ToList();
        }
        public ActionResult<List<ProductViewModel>> getAllProduct()
        {
              var prods = (
                from p in _context.Products
                join c in _context.Categories
                on Int32.Parse( p.Category) equals c.Id
                select new ProductViewModel{
                     Id = p.Id,
                    Category = c.Id,
                    CategoryName = c.Name,
                    Name = p.Name,
                    Units = p.Units,
                    Stock = p.Stock,
                    Price = p.Price,
                    Status = p.Status
                }).ToList();
            return prods;
        }
          public IActionResult saveCategory(Product p){
            p.Status = "Active";
            _context.Products.Add(p);
            _context.SaveChanges();
            return Ok();
        }
        
    }
}
