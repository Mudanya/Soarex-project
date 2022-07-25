using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.Terms
{
    public class TermsUpsertDto
    {
        [Required(ErrorMessage = "Description is required")]
        public string Desc { get; set; }
    }
}
