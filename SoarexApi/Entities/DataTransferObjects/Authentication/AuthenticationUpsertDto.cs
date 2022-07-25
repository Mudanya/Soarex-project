using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.Authentication
{
    public class AuthenticationUpsertDto
    {
        [Required(ErrorMessage = "User name is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password name is required")]
        public string Password { get; set; }
    }
}
