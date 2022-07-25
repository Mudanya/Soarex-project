using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Settings
{
    public class SettingsDto
    {
        public Guid Id { get; set; }
        public string Logo { get; set; }
        public string HeroName { get; set; }
        public string HeroDesc { get; set; }
        public string HeroImage { get; set; }
        public string Slogan { get; set; }
        public string StrengthDesc { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string FbLink { get; set; }
        public string InstaLink { get; set; }
        public string InLink { get; set; }
        public string TwitLink { get; set; }
    }
}
