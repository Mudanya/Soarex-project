using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Settings
{
    public class SettingsUpsertDto
    {
        public string? Logo { get; set; }
        [Required(ErrorMessage = "Hero Name is required")]
        public string HeroName { get; set; }
        [Required(ErrorMessage = "Hero Description is required")]
        public string HeroDesc { get; set; }
        public string? HeroImage { get; set; }
       
        [Required(ErrorMessage = "Slogan is required")]
        public string Slogan { get; set; }
        [Required(ErrorMessage = "Strength Description is required")]
        public string StrengthDesc { get; set; }
        [Required(ErrorMessage = "Phone number is Mandatory")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Email is Mandatory")]
        public string Email { get; set; }
        public string? FbLink { get; set; }
        public string? InstaLink { get; set; }
        public string? InLink { get; set; }
        public string? TwitLink { get; set; }
    }
}
