using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Catagories;
            return View(objCategoryList);
        }

        //Get
        [HttpGet]
        public IActionResult Create()
        {
           return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //Post
        public IActionResult Create(Category obj)
        {
            _db.Catagories.Add(obj);
            _db.SaveChanges();
            //If you want to redirect to other controller specify the name of controller as well......
            return RedirectToAction("Index");
        }
    }
}
