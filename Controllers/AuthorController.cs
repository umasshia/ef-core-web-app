using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ef_core_web_app.Models;

namespace ef_core_web_app.Controllers{
    public class AuthorController : Controller{
        public async Task<IActionResult> Index() {
            using (var context = new EFCoreWebAppContext()){
                var model = await context.Authors.AsNoTracking().ToListAsync();
                return View(model);
            }
        }
        [HttpGet]
        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FirstName,LastName")] Author author) {
            using (var context = new EFCoreWebAppContext()){
                context.Add(author);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
        }
    }
}