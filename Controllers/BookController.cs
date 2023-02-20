using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using ef_core_web_app.Models;

namespace ef_core_web_app.Controllers {
    public class BookController : Controller {
        public async Task<IActionResult> Index() {
            using (var context = new EFCoreWebAppContext()){
                var model = await context.Authors.Include(a => a.Books).AsNoTracking().ToListAsync();
                return View(model);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Create() {
            using(var context = new EFCoreWebAppContext()){
                var authors = await context.Authors.Select(a => new SelectListItem {
                    Value = a.AuthorId.ToString(),
                    Text = $"{a.FirstName} {a.LastName}"
                }).ToListAsync();
                ViewBag.Authors = authors;
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Title,AuthorId")] Book book) {
            using(var context = new EFCoreWebAppContext()){
                context.Books.Add(book);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
        }
    }
}