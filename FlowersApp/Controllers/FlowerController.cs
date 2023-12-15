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
            FlowerModel flower = _context.Flowers.First(i => i.Id == Id);

            return View(flower);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var flower = _context.Flowers.Where(i => i.Id == id).FirstOrDefault();
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
    }
}
