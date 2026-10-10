using Bookshelf.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bookshelf.Controllers;

public class BooksController : Controller
{
    static List<Book> books = new()
    {
        new Book { Id = 1, Title = "Things Fall Apart",       Author = "Chinua Achebe",     Pages = 209, IsRead = true  },
        new Book { Id = 2, Title = "The Hobbit",              Author = "J.R.R. Tolkien",    Pages = 310, IsRead = true  },
        new Book { Id = 3, Title = "Beloved",                 Author = "Toni Morrison",     Pages = 324, IsRead = false },
        new Book { Id = 4, Title = "Dune",                    Author = "Frank Herbert",     Pages = 688, IsRead = false },
        new Book { Id = 5, Title = "Brown Girl, Brownstones", Author = "Paule Marshall",    Pages = 310, IsRead = true  },
        new Book { Id = 6, Title = "The Alchemist",           Author = "Paulo Coelho",      Pages = 208, IsRead = false },
    };

    [Route("/books")]
public IActionResult Index()
    {
        return View(books);
    }
    [Route("/books/{id}")]
    public IActionResult Details(int id)
    {
        var book = books.FirstOrDefault(b => b.Id == id);
        if (book == null)
        {
            return NotFound();
        }
        return View(book);
    }

    [Route("/books/{id:int}/mark-read")]
    public IActionResult MarkRead(int id)
    {
        var book = books.FirstOrDefault(b => b.Id == id);
        if (book == null)
        {
            return NotFound();
        }

        book.IsRead = true;
        TempData["Message"] = $"Marked {book.Title} as read";
        return RedirectToAction("Index");
    }

}
