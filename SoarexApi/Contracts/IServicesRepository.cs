using Entities.Models;

namespace Contracts
{
    public interface IServicesRepository
    {
        void CreateService(Service services);
        void UpdateService(Service services);
        void DeleteService(Service services);
        Task<Service> GetService(Guid id, bool trackChanges);
        Task<IEnumerable<Service>> GetAllServices(bool trackChanges);
    }
}
