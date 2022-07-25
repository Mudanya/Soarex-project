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
    public class AboutUsRepository : RepositoryBase<AboutUs>, IAboutUsRepository
    {
        public AboutUsRepository(RepositoryContext context) : base(context)
        {

        }

        public void CreateAboutUs(AboutUs about)
        => Create(about);

        public async Task<AboutUs> GetAboutUsAsync(bool trackChanges)
        => await Find(trackChanges).FirstOrDefaultAsync();

        public void UpdateAboutUs(AboutUs about)
        => Update(about);
    }
}
