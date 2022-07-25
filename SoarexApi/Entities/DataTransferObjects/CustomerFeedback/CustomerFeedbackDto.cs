using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.CustomerFeedback
{
    public class CustomerFeedbackDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public bool IsPublished { get; set; }
        public Guid ApplicationUserId { get; set; }
        public string Customer { get; set; }
    }
}
