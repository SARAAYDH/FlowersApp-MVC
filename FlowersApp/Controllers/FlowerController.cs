using FlowersApp.Data;
using FlowersApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FlowersApp.Controllers
{
    public class FlowerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FlowerController( ApplicationDbContext context)
        {
            
            _context = context;
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        } 
        public IActionResult Index()
        {
            var list_flowers = _context.Flowers.ToList();
           
                return View(list_flowers);
            
        }

        [HttpGet]
        public IActionResult InputForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(FlowerModel flower)
        {
            if (flower != null) 
            { 
            _context.Flowers.Add(flower);
            _context.SaveChanges();
            }
            return RedirectToAction("Index");

        }
        public IActionResult Details(int Id)
        {
            //error
            FlowerModel flower = _context.Flowers.FirstOrDefault(i => i.Id == Id);
            if (flower is null) { throw new Exception("the id could not be found"); }

            return View(flower);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var flower = _context.Flowers.FirstOrDefault(i => i.Id == id);
            return View(flower);
        }
        [HttpPost]
        public IActionResult Edit(FlowerModel Model)
        {
            
           var flower = _context.Flowers.Where(i => i.Id == Model.Id).FirstOrDefault();
            if (flower != null)
            {
                flower.Name = Model.Name;
                flower.Description = Model.Description;
                flower.Status = Model.Status;
                flower.StockQuantity = Model.StockQuantity;
                flower.Price = Model.Price;
                _context.SaveChanges();

            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var flower = _context.Flowers.Where(i => i.Id == id).FirstOrDefault();
            return View(flower);
        }
        [HttpPost]

        public IActionResult Delete(FlowerModel Model)
        {

            var flower = _context.Flowers.Where(i => i.Id == Model.Id).FirstOrDefault();
            if (flower != null)
            {
                _context.Flowers.Remove(flower);
                _context.SaveChanges();

            }
            return RedirectToAction("Index");
        }
        public IActionResult Search(string searchedTerm)
        {
            var flower= from g in _context.Flowers where g.Name.Contains(searchedTerm) select g;
            return View("Index",flower);
        }

    }
}
