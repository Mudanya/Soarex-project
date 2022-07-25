using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.UtilityServices
{
    public class UtilityServiceUpsertDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Desc { get; set; }
    }
}
