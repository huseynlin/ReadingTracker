using System.ComponentModel.DataAnnotations;

namespace ReadingTracker.Models
{
    public class User
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required(ErrorMessage = "İstifadəçi adı qeyd olunmalıdır")]
        public string Username { get; set; } = string.Empty; // <-- Düzəliş

        [Required(ErrorMessage = "Şifrə qeyd olunmalıdır")]
        public string Password { get; set; } = string.Empty; // <-- Düzəliş
    }
}