using Filmy.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Filmy.Models;

namespace Filmy.Controllers
{
    public class FilmController : Controller
    {

        private static IList<Book> books = new List<Book>
        {
            new Book(){Id = 1, Tytul = "In search of a lost time", Opis = "Swann's Way, the first part of A la recherche de temps perdu, Marcel Proust's seven-part cycle, was published in 1913. In it, Proust introduces the themes that run through the entire work.", Ocena=3 },
            new Book(){Id = 2, Tytul = "Ulysses", Opis = "Ulysses chronicles the passage of Leopold Bloom through Dublin during an ordinary day, June 16, 1904.", Ocena=4 },
            new Book(){Id = 4, Tytul = "The Great Gatsby", Opis = "The novel chronicles an era that Fitzgerald himself dubbed the Jazz Age.", Ocena=5 },
            new Book(){Id = 5, Tytul = "Don Quixote", Opis = "Alonso Quixano, a retired country gentleman in his fifties, lives in an unnamed section of La Mancha with his niece and a housekeeper.", Ocena=6 },
            new Book(){Id = 6, Tytul = "One Hundred Years of Solitude", Opis = "One of the 20th century's enduring works, One Hundred Years of Solitude is a widely beloved and acclaimed novel known throughout the world.", Ocena=5 },
            new Book(){Id = 7, Tytul = "Moby Dick", Opis = "First published in 1851, Melville's masterpiece is, in Elizabeth Hardwick's words, the greatest novel in American literature.", Ocena=6 },
            new Book(){Id = 8, Tytul = "War and Peace", Opis = "Epic in scale, War and Peace delineates in graphic detail events leading up to Napoleon's invasion of Russia.", Ocena=3 },
        };
        // GET: FilmController
        public ActionResult Index()
        {
            return View(books);
        }

        // GET: FilmController/Details/5
        public ActionResult Details(int id)
        {
            return View(books.FirstOrDefault(x=>x.Id==id));
        }

        // GET: FilmController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FilmController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            book.Id = books.Count + 1;
            books.Add(book);
            return RedirectToAction("Index");
        }
        

        // GET: FilmController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FilmController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book editedBook)
        {
            var existingBook = books.FirstOrDefault(x => x.Id == editedBook.Id);
            existingBook.Tytul = editedBook.Tytul;
            existingBook.Opis = editedBook.Opis;
            existingBook.Ocena = editedBook.Ocena;
            return RedirectToAction("Index");
        }

        // GET: FilmController/Delete/5
        public ActionResult Delete(int id)
        {
            var w = books.FirstOrDefault(x => x.Id == id);
            ViewBag.Id = w.Id;
            ViewBag.Tytul = w.Tytul;
            ViewBag.Opis = w.Opis;
            ViewBag.Ocena = w.Ocena;
            return View();
        }

        // POST: FilmController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var book = books.FirstOrDefault(x => x.Id == id);
            books.Remove(book);
            return RedirectToAction("Index");
        }
    }
}
