using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.CustomerFeedback
{
    public class CustomerFeedbackUpsertDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Desc { get; set; }
        public bool? IsPublished { get; set; }
        public Guid? ApplicationUserId { get; set; }
    }
}
