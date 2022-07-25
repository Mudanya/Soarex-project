using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class ApplicationUserCreateDto
    {
        [Required(ErrorMessage = "Full name is required")]
        [MinLength(6, ErrorMessage = "Full name length should be atleast 6 characters")]
        [RegularExpression(@"\w")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress, ErrorMessage ="Incorrect email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

    }
}
