using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HW27.Db;
using HW27.Models;
using Microsoft.AspNetCore.Mvc;

namespace HW27.Controllers
{
    public class ComputersController : Controller
    {
        public DataContext _context;

        public ComputersController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Categories = _context.Categories.ToList();
            var products = _context.Products.ToList();
            return View(products);
        }
       
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Category = _context.Categories.ToList();
            return View();
        }
       
        [HttpPost]
        public IActionResult Add(Product p)
        {
            p.CategoryId = int.Parse(Request.Form["CategoryId"]);
            _context.Add(p);
            var cat = _context.Categories.Find(p.CategoryId);
            cat.Products.Add(p);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
       
        [HttpGet]
        public IActionResult Change()
        {
            ViewBag.Category = _context.Categories.ToList();
            return View();
        }
        
        [HttpPost]
        public IActionResult Change(Product p)
        {
            
            var product = _context.Products.Find(p.Id);
            Category neCat;
            Category oldCat;
            if (p.CategoryId != product.CategoryId)
            {
                neCat = _context.Categories.Find(p.CategoryId);
                oldCat = _context.Categories.Find(product.CategoryId);
                oldCat.Products.Remove(product);
                neCat.Products.Add(p);
            }
            product.Name = p.Name;
            product.Model = p.Model;
            product.Memory = p.Memory;
            product.Prise = p.Prise;
            product.CategoryId = p.CategoryId;
            product.Category = _context.Categories.Find(product.CategoryId);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
       
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(Product p)
        {
            var product = _context.Products.Find(p.Id);
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
       
        [HttpGet]
        public IActionResult Categories()
        {
            var p = _context.Products.ToList();
            ViewBag.Categories = _context.Categories.ToList();
            return View(p);
        }
       
        [HttpPost]
        public IActionResult Categories(int Id)
        {
            
            var p = _context.Products.Where(x => x.CategoryId == Id).Select(x => x).ToList();
            ViewBag.Categories = _context.Categories.ToList();
            return View(p);
        }


    }
}
