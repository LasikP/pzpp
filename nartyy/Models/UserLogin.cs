using System.ComponentModel.DataAnnotations;

namespace nartyy.Models
{
    public class UserLogin
    {
        [Required(ErrorMessage = "Pole Nazwa Użytkownika nie może być puste")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Pole Hasło nie może być puste")]
        public string Password { get; set; }
    }
}
