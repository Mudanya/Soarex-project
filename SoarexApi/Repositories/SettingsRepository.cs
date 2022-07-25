using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace Repository
{
    public class SettingsRepository : RepositoryBase<Settings>, ISettingsRepository
    {
        public SettingsRepository(RepositoryContext context) : base(context)
        {

        }

        public void CreateSettings(Settings settings)
            => Create(settings);

        public async Task<Settings> GetSettingsAsync(bool trackChanges)
        => await Find(trackChanges).FirstOrDefaultAsync();

        public void UpdateSettings(Settings settings)
        => Update(settings);
    }
}
