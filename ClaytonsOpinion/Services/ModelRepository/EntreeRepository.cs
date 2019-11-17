using ClaytonsOpinion.Data;
using ClaytonsOpinion.Data.BizModels;
using ClaytonsOpinion.Services.InterfaceAndAbstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaytonsOpinion.Services.ModelRepository
{
    public class EntreeRepository : RepositoryBase<Entree>, IEntreeRespository
    {
        public EntreeRepository(ApplicationDbContext repositoryContext) 
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Entree>> GetAllEntreesAsync()
        {
            return await FindAll().OrderBy(e => e.Name).ToListAsync();
        }

        public async Task<Entree> GetEntreeByIdAsync(int entreeId)
        {
            return await FindByCondition(e => e.Id.Equals(entreeId)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Entree>> GetEntreesByNameAsync(string name)
        {
            if(name == null)
                return await FindAll().OrderBy(e => e.Name).ToListAsync();

            return await FindByCondition(e => e.Name.Contains(name)).ToListAsync();
        }

        public async Task<IEnumerable<Entree>> GetEntreesByRestaurantAsync(int restaurantId)
        {
            return await FindByCondition(e => e.Restaurant.Id.Equals(restaurantId)).ToListAsync();
        }

        public Task<Entree> GetEntreeWithDetailsAsync(int entreeId)
        {
            throw new NotImplementedException();
        }

        public void UpdateEntree(Entree entree)
        {
            throw new NotImplementedException();
        }

        public void CreateEntree(Entree entree)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntree(Entree entree)
        {
            throw new NotImplementedException();
        }
    }
}
