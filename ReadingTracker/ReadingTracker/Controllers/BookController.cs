using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadingTracker.Models;
using ReadingTracker.Services;
using System.Security.Claims;

namespace ReadingTracker.Controllers
{
    [Authorize] // Yalnız giriş etmiş istifadəçilər daxil ola bilər
    public class BookController : Controller
    {
        private readonly JsonDataService _dataService;

        public BookController(JsonDataService dataService)
        {
            _dataService = dataService;
        }

        // Cari istifadəçinin ID-sini təhlükəsiz şəkildə götürmək üçün metod
        private string GetCurrentUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;

        // KİTAB SİYAHISI (FİLTR İLƏ)
        [Route("books/my-list")]
        public IActionResult Index(BookStatus? statusFilter)
        {
            var userId = GetCurrentUserId();
            var allBooks = _dataService.GetBooks() ?? new List<Book>();

            // Yalnız daxil olan istifadəçinin kitablarını götürürük
            var userBooks = allBooks.Where(b => b.UserId == userId).ToList();

            if (statusFilter.HasValue)
            {
                userBooks = userBooks.Where(b => b.Status == statusFilter.Value).ToList();
            }

            ViewBag.CurrentFilter = statusFilter;
            return View(userBooks);
        }

        // KİTABIN DETALLARI (BAX)
        [Route("books/details/{id}")]
        public IActionResult Details(string id)
        {
            var books = _dataService.GetBooks() ?? new List<Book>();
            var book = books.FirstOrDefault(b => b.Id == id && b.UserId == GetCurrentUserId());

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // YENİ KİTAB YARATMA (SƏHİFƏNİ AÇIR)
        [HttpGet]
        [Route("books/create")]
        public IActionResult Create()
        {
            return View();
        }

        // YENİ KİTAB YARATMA (FORMU QƏBUL EDİR)
        [HttpPost]
        [Route("books/create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            // UserId-ni formdan yox, daxildən götürürük
            ModelState.Remove("UserId");
            ModelState.Remove("Id");

            if (ModelState.IsValid)
            {
                book.Id = Guid.NewGuid().ToString();
                book.UserId = GetCurrentUserId();
                book.Status = BookStatus.Oxunur; // Yeni kitab həmişə "Oxunur" statusunda başlayır

                var books = _dataService.GetBooks() ?? new List<Book>();
                books.Add(book);
                _dataService.SaveBooks(books);

                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // KİTABI "BİTİRİLDİ" HALINA SALIR
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("books/mark-finished/{id}")]
        public IActionResult MarkAsFinished(string id)
        {
            var books = _dataService.GetBooks() ?? new List<Book>();
            var book = books.FirstOrDefault(b => b.Id == id && b.UserId == GetCurrentUserId());

            if (book != null)
            {
                book.Status = BookStatus.Bitirilib;
                _dataService.SaveBooks(books);
            }

            return RedirectToAction(nameof(Index));
        }

        // KİTABI SİLİR
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("books/delete/{id}")]
        public IActionResult Delete(string id)
        {
            var books = _dataService.GetBooks() ?? new List<Book>();
            var book = books.FirstOrDefault(b => b.Id == id && b.UserId == GetCurrentUserId());

            if (book != null)
            {
                books.Remove(book);
                _dataService.SaveBooks(books);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}