using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Enquiry
{
    public class EnquiryUpsertDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Desc { get; set; }
        public string? Timeline { get; set; }
        [Required]
        public string Description { get; set; }
        public string? Notes { get; set; }
    }
}
