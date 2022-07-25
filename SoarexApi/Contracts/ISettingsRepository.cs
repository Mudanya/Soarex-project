using Entities.Models;

namespace Contracts
{
    public interface ISettingsRepository
    {
        void CreateSettings(Settings settings);
        void UpdateSettings(Settings settings);
        Task<Settings> GetSettingsAsync(bool trackChanges);
    }
}
