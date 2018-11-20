

namespace ReactDemoWebApp.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AccountControllerModel
    {
    }

    public class LoginModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
