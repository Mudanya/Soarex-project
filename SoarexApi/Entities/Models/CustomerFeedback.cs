namespace Entities.Models
{
    public class CustomerFeedback
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public bool IsPublished { get; set; }
        public Guid ApplicationUserId { get; set; }
        public ApplicationUser Customer { get; set; }


    }
}
