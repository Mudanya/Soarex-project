using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class KeyAreasRepository :RepositoryBase<KeyAreas>, IKeyAreasRepository
    {
        public KeyAreasRepository(RepositoryContext context):base(context)
        {

        }
        public void CreateKeyAreas(KeyAreas keyAreas) => Create(keyAreas);

        public async Task<KeyAreas> GetKeyAreasAsync(bool trackChanges) =>
            await Find(trackChanges).FirstOrDefaultAsync();

        public void UpdateKeyAreas(KeyAreas keyAreas)=>Update(keyAreas);
    }
}
