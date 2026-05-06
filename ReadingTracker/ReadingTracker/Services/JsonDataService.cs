using System.Text.Json;
using ReadingTracker.Models;

namespace ReadingTracker.Services
{
    public class JsonDataService
    {
        private readonly string _usersFilePath = "Data/users.json";
        private readonly string _booksFilePath = "Data/books.json";

        // JSON faylları yoxdursa avtomatik yaradır
        public JsonDataService()
        {
            if (!Directory.Exists("Data")) Directory.CreateDirectory("Data");
            if (!File.Exists(_usersFilePath)) File.WriteAllText(_usersFilePath, "[]");
            if (!File.Exists(_booksFilePath)) File.WriteAllText(_booksFilePath, "[]");
        }

        // --- İSTİFADƏÇİ (USER) ƏMƏLİYYATLARI ---
        public List<User> GetUsers()
        {
            var json = File.ReadAllText(_usersFilePath);
            return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
        }

        public void SaveUsers(List<User> users)
        {
            var json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_usersFilePath, json);
        }

        // --- KİTAB (BOOK) ƏMƏLİYYATLARI ---
        public List<Book> GetBooks()
        {
            var json = File.ReadAllText(_booksFilePath);
            return JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();
        }

        public void SaveBooks(List<Book> books)
        {
            var json = JsonSerializer.Serialize(books, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_booksFilePath, json);
        }
    }
}