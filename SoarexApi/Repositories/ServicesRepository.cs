using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace Repository
{
    public class ServicesRepository : RepositoryBase<Service>, IServicesRepository
    {
        public ServicesRepository(RepositoryContext context) : base(context)
        {

        }

        public void CreateService(Service services)
        => Create(services);

        public async Task<IEnumerable<Service>> GetAllServices(bool trackChanges)
        => await FindAll(trackChanges).ToListAsync();

        public async Task<Service> GetService(Guid id,bool trackChanges)
        => await FindByCondition(s=>s.Id == id, trackChanges).FirstOrDefaultAsync();

        public void UpdateService(Service services)
        => Update(services);
        public void DeleteService(Service services)
        => Delete(services);
    }
}
