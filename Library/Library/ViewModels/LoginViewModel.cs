using System.ComponentModel.DataAnnotations;

namespace Library.ViewModels
{
    public class LoginViewModel
    {
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
    }
}