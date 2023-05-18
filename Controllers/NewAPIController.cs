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
                on  p.Category equals c.Id
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
            return Ok(prods);
        }
      
      public IActionResult addProduct(Product p)
        {
            if(string.IsNullOrEmpty(p.Status) || p.Status == "false")
            {
                p.Status = "Inactive";
            }
            _context.Products.Add(p);
            _context.SaveChanges();
            return Ok();
        }

        public IActionResult updateProduct(Product p)
        {
            if(string.IsNullOrEmpty(p.Status) || p.Status == "false")
            {
                p.Status = "Inactive";
            }
            else
            {
                p.Status = "Active";
            }
            _context.Products.Update(p);
            _context.SaveChanges();
            return Ok();
        } 

         public IActionResult deleteProduct(int id)
        {
            var res = _context.Products.Where(q => q.Id == id).FirstOrDefault();
            _context.Products.Remove(res);
            _context.SaveChanges();
            
            return Ok();
        }

        public IActionResult addStockProduct(Product p, int iStock,string date)
        {
            Stockhistory sh = new Stockhistory();

            p.Stock += iStock;
            _context.Products.Update(p);

            sh.AddedStock = iStock;
            sh.ProdId = p.Id;
            sh.Date = date;

            _context.Stockhistories.Add(sh);
            _context.SaveChanges();
            return Ok();
        }

        public ActionResult<List<Product>> viewStockHistory(int id){
            
            //return _context.Products.ToList();
            var res = _context.Stockhistories.ToList().Where(p => p.ProdId == id);

            return Ok(res);
        }     
    }
}
