using BookCatalog.Data;
using BookCatalog.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace BookCatalog.Controllers
{
    public class BookController(ApplicationDbContext _context) : Controller
    {
        public IActionResult Index()
        {
            var books = _context.Books.ToList();
            return View(books);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Add(book);
                _context.SaveChanges();
                Log.Information("New book added: {@Book}", book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }
    }
}
