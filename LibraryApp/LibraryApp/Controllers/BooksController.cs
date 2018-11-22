using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace LibraryApp.Controllers
{
    public class BooksController : Controller
    {
        private readonly LibraryAppContext _context;

        public BooksController(LibraryAppContext context)
        {
            _context = context;
        }

        [Authorize(Roles ="Member,Admin")]
        

        // GET: Books
        public async Task<IActionResult> Index(string searchString, string catChoice, string sortOrder, string currentFilter, int? page, string currentCatChoice)

        {
            ViewData["CurrentSort"] = sortOrder;
            
            
            ViewData["NameSortParam"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["AuthorSortParam"] = String.IsNullOrEmpty(sortOrder) ? "author_asc" : "";
            ViewData["YearSortParam"] = sortOrder == "Year" ? "year_desc" : "Year";
            ViewData["AvailSortParam"] = sortOrder =="avail" ? "avail_desc" : "avail";

            if (searchString !=null)
            {
                page = 1;

            }
            else
            {
                searchString = currentFilter;
            }

           

            ViewData["CurrentFilter"] = searchString;
          

            var books = _context.Book
                        .Include(b => b.Borrower)
                        .AsNoTracking();

            switch (sortOrder)
            {
                case "name_desc":
                    books = books.OrderByDescending(b => b.Name);
                    break;

                case "Year":
                    books = books.OrderBy(b => b.Year);
                    break;

                case "year_desc":
                    books = books.OrderByDescending(b => b.Year);
                    break;
                case "author_asc":
                    books = books.OrderBy(b => b.Author);
                    break;

                case "avail":
                    books = books.OrderBy(b => b.BorrowerId);
                    break;

                case "avail_desc":
                    books = books.OrderByDescending(b => b.BorrowerId);
                    break;
                default:
                    books = books.OrderBy(b => b.Name);                    
                    break;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(b => b.Name.Contains(searchString) || b.Author.Contains(searchString));
            }

           
            int pageSize = 8;
            return View(await PaginatedList<Book>.CreateAsync(books, page ?? 1, pageSize));

          //  return View(await books.ToListAsync());
        }

  




        // GET: Books/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .Include(b => b.Borrower)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
           
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("BookId,Name,Author,Year")] Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(book);
        }

        [Authorize(Roles ="Admin")]
        public async Task<ActionResult> Checkout (int? id)
        {
            if (id==null)
            {
                return NotFound();
            }

            var book = await _context.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["BorrowerId"] = new SelectList(_context.Borrower, "Id", "Name", book.BorrowerId);
            return View(book);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Checkout(int id, [Bind("BookId,Name,Author,Year,BorrowerId")] Book book)
        {
            if (id != book.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.BookId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BorrowerId"] = new SelectList(_context.Borrower, "Id", "Name", book.BorrowerId);
            return View(book);
        }

        // GET: Books/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("BookId,Name,Author,Year,BorrowerId")] Book book)
        {
            if (id != book.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.BookId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BorrowerId"] = new SelectList(_context.Borrower, "Id", "Name", book.BorrowerId);
            return View(book);
        }

        // GET: Books/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .Include(b => b.Borrower)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Book.FindAsync(id);
            _context.Book.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Return(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .Include(b => b.Borrower)
                .FirstOrDefaultAsync(m => m.BookId == id);

            if (book == null)
            {
                return NotFound();
            }
            
            return View(book);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Return(int id, [Bind("BookId,Name,Author,Year,BorrowerId")] Book returnbook)
        {
            if (id != returnbook.BookId)
            {
                return NotFound();
            }

            returnbook.BorrowerId = null;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(returnbook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(returnbook.BookId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
               
            }

            return RedirectToAction(nameof(Index));
        }



        private bool BookExists(int id)
        {
            return _context.Book.Any(e => e.BookId == id);
        }
    }
}
