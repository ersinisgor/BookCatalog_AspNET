using BookCatalog.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalog.Controllers
{
    public class BookController(ApplicationDbContext _context) : Controller
    {
        public IActionResult Index()
        {
            var books = _context.Books.ToList();
            return View(books);
        }
    }
}
