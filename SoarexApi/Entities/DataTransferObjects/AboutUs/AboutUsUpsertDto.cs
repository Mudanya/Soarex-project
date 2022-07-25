using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.AboutUs
{
    public class AboutUsUpsertDto
    {
        [Required(ErrorMessage = "Brief Description is required")]
        public string MiniDesc { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Desc { get; set; }
        public string? ImageOne { get; set; }
        public string? ImageTwo { get; set; }
    }
}
