using System.ComponentModel.DataAnnotations;

namespace Library.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]

        public string UserSurname { get; set; }

        public string UserPhone { get; set; }

        [Required]

        public string UserEmail { get; set; }

        [Required]

        public string UserPassword { get; set; }
    }
}