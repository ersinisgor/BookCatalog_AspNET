using BookCatalog.Application.Services;
using BookCatalog.Shared.DTOs;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace BookCatalog.Presentation.Controllers
{
    public class BookController(IValidator<CreateBookDTO> createValidator,[FromServices] IBookService bookService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            try
            {
                var books = await bookService.GetBooksAsync();
                return View(books);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error retrieving books");
                TempData["ErrorMessage"] = "There was an error fetching the books.";
                return View("Error");
            }
        }

        public IActionResult Create()
        {
            return View(new CreateBookDTO());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] CreateBookDTO createDto)
        {
            try
            {
                var validationResult = await createValidator.ValidateAsync(createDto);
                if (!validationResult.IsValid)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }
                    return View(createDto);
                }

                await bookService.AddBookAsync(createDto);
                Log.Information("New book added: {@Book}", createDto);
                TempData["SuccessMessage"] = $"Book '{createDto.Title}' successfully added.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error adding new book");
                TempData["ErrorMessage"] = "An error occurred while adding a new book.";
                return View("Error");
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var book = await bookService.GetBookByIdAsync(id);
                if (book == null)
                {
                    TempData["ErrorMessage"] = "Book not found.";
                    return NotFound();
                }
                return View(book);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error retrieving book details for ID={Id}", id);
                TempData["ErrorMessage"] = "An error occurred while fetching book details.";
                return View("Error");
            }
        }

        //public async Task<IActionResult> Create([FromForm] Book book)
        //{
        //    try
        //    {
        //        var validationResult = await _validator.ValidateAsync(book);
        //        if (!validationResult.IsValid)
        //        {
        //            foreach (var error in validationResult.Errors)
        //            {
        //                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
        //            }
        //            return View(book);
        //        }

        //        _context.Books.Add(book);
        //        await _context.SaveChangesAsync();
        //        Log.Information("New book added: {@Book}", book);
        //        TempData["SuccessMessage"] = $"Kitap '{book.Title}' başarıyla eklendi.";
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(ex, "Error adding new book");
        //        TempData["ErrorMessage"] = "Yeni kitap eklenirken bir hata oluştu.";
        //        return View("Error");
        //    }
        //}

        //public async Task<IActionResult> Edit([FromRoute] int id)
        //{
        //    try
        //    {
        //        var book = await _context.Books.FindAsync(id);
        //        if (book == null)
        //        {
        //            TempData["ErrorMessage"] = "Kitap bulunamadı.";
        //            return NotFound();
        //        }
        //        return View(book);
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(ex, "Error retrieving book for edit");
        //        TempData["ErrorMessage"] = "Kitap düzenleme için getirilirken bir hata oluştu.";
        //        return View("Error");
        //    }
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit([FromRoute] int id, [FromForm] Book book)
        //{
        //    try
        //    {
        //        if (id != book.Id)
        //        {
        //            TempData["ErrorMessage"] = "Geçersiz kitap kimliği.";
        //            return BadRequest();
        //        }

        //        var validationResult = await _validator.ValidateAsync(book);
        //        if (!validationResult.IsValid)
        //        {
        //            foreach (var error in validationResult.Errors)
        //            {
        //                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
        //            }
        //            return View(book);
        //        }

        //        _context.Update(book);
        //        await _context.SaveChangesAsync();
        //        Log.Information("Book updated: {@Book}", book);
        //        TempData["SuccessMessage"] = $"Kitap '{book.Title}' başarıyla güncellendi.";
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(ex, "Error updating book");
        //        TempData["ErrorMessage"] = "Kitap güncellenirken bir hata oluştu.";
        //        return View("Error");
        //    }
        //}

        //public async Task<IActionResult> Delete([FromRoute] int id)
        //{
        //    try
        //    {
        //        var book = await _context.Books.FindAsync(id);
        //        if (book == null)
        //        {
        //            TempData["ErrorMessage"] = "Kitap bulunamadı.";
        //            return NotFound();
        //        }
        //        return View(book);
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(ex, "Error retrieving book for deletion");
        //        TempData["ErrorMessage"] = "Kitap silme için getirilirken bir hata oluştu.";
        //        return View("Error");
        //    }
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed([FromRoute] int id)
        //{
        //    try
        //    {
        //        var book = await _context.Books.FindAsync(id);
        //        if (book == null)
        //        {
        //            TempData["ErrorMessage"] = "Kitap bulunamadı.";
        //            return RedirectToAction(nameof(Index));
        //        }

        //        _context.Books.Remove(book);
        //        await _context.SaveChangesAsync();
        //        Log.Information("Book deleted: Id={Id}, Title={Title}", id, book.Title);
        //        TempData["SuccessMessage"] = $"Kitap '{book.Title}' başarıyla silindi.";
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(ex, "Error deleting book with Id={Id}", id);
        //        TempData["ErrorMessage"] = "Kitap silinirken bir hata oluştu.";
        //        return RedirectToAction(nameof(Index));
        //    }
        //}
    }
}