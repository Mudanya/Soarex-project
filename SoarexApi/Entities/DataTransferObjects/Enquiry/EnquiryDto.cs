using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Enquiry
{
    public class EnquiryDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string Timeline { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
    }
}
