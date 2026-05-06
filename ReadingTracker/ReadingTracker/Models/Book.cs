using System.ComponentModel.DataAnnotations;

namespace ReadingTracker.Models
{
    public enum BookStatus { Oxunur = 0, Bitirilib = 1 }

    public class Book
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required(ErrorMessage = "Kitabın adı mütləq qeyd olunmalıdır.")]
        public string Title { get; set; } = string.Empty; // <-- Düzəliş

        [Required(ErrorMessage = "Müəllif adı mütləq qeyd olunmalıdır.")]
        public string Author { get; set; } = string.Empty; // <-- Düzəliş

        public string? Summary { get; set; } // <-- Düzəliş (Qısa məzmun boş ola bilər deyə sonuna ? qoyuruq)

        public BookStatus Status { get; set; } = BookStatus.Oxunur;
        public string? UserId { get; set; }
    }
}