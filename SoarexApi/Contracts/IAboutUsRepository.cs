using Entities.Models;

namespace Contracts
{
    public interface IAboutUsRepository
    {
        void CreateAboutUs(AboutUs about);
        void UpdateAboutUs(AboutUs about);
        Task<AboutUs> GetAboutUsAsync(bool trackChanges);
    }
}
