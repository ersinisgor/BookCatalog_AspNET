using BookCatalog.Data;
using BookCatalog.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace BookCatalog.Controllers
{
    public class BookController(ApplicationDbContext _context, IValidator<Book> _validator) : Controller
    {
        public async Task<IActionResult> Index()
        {
            try
            {
                var books = await _context.Books.ToListAsync();
                return View(books);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error retrieving books");
                return View("Error");
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] Book book)
        {
            var validationResult = _validator.Validate(book);
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(book);
            }

            _context.Books.Add(book);
            _context.SaveChanges();
            Log.Information("New book added: {@Book}", book);
            return RedirectToAction(nameof(Index));

            //if (ModelState.IsValid)
            //{
            //    _context.Books.Add(book);
            //    _context.SaveChanges();
            //    Log.Information("New book added: {@Book}", book);
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(book);
        }
    }
}
