using debbi.Data;
using debbi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace debbi.Controllers
{
    public class MyNewModelController : Controller
    {
        private readonly ApplicationDbContext _db;

        public MyNewModelController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<MyNewModel> objList = _db.MyNewModel;
            return View(objList);
        }
        //GET - CREATE
        public IActionResult Create()
        {
            return View();
        }
        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MyNewModel obj)
        {
            _db.MyNewModel.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
