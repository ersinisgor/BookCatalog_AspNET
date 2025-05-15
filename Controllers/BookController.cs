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
        public async Task<IActionResult> Create([FromForm] Book book)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(book);
                if (!validationResult.IsValid)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }
                    return View(book);
                }

                _context.Books.Add(book);
                await _context.SaveChangesAsync();
                Log.Information("New book added: {@Book}", book);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error adding new book");
                return View("Error");
            }
        }

        public async Task<IActionResult> Edit([FromRoute] int id)
        {
            try
            {
                var book = await _context.Books.FindAsync(id);
                if (book == null)
                {
                    return NotFound();
                }
                return View(book);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error retrieving book for edit");
                return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromForm] Book book)
        {
            try
            {
                if (id != book.Id)
                {
                    return BadRequest();
                }

                var validationResult = await _validator.ValidateAsync(book);
                if (!validationResult.IsValid)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }
                    return View(book);
                }

                _context.Update(book);
                await _context.SaveChangesAsync();
                Log.Information("Book updated: {@Book}", book);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error updating book");
                return View("Error");
            }
        }

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var book = await _context.Books.FindAsync(id);
                if (book == null)
                {
                    return NotFound();
                }
                return View(book);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error retrieving book for deletion");
                return View("Error");
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed([FromRoute] int id)
        {
            try
            {
                var book = await _context.Books.FindAsync(id);
                if (book != null)
                {
                    _context.Books.Remove(book);
                    await _context.SaveChangesAsync();
                    Log.Information("Book deleted: Id={Id}", id);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error deleting book");
                return View("Error");
            }
        }
    }
}
