﻿using ClaytonsOpinion.Data;
using ClaytonsOpinion.Data.BizModels;
using ClaytonsOpinion.Services.InterfaceAndAbstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaytonsOpinion.Services.ModelRepository
{
    public class EntreeRepository : RepositoryBase<Entree>, IEntreeReviewRespository
    {
        public EntreeRepository(ApplicationDbContext repositoryContext) 
            : base(repositoryContext)
        {
        }

        #region Async Methods

        public async Task<IEnumerable<Entree>> GetAllEntreesAsync()
        {
            return await FindAll().OrderBy(e => e.Name).ToListAsync();
        }

        public async Task<Entree> GetEntreeByIdAsync(int entreeId)
        {
            return await FindByCondition(e => e.Id.Equals(entreeId)).Include(m => m.Restaurant).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Entree>> GetEntreesByNameAsync(string name)
        {
            if(name == null)
                return await FindAll().OrderBy(e => e.Name).ToListAsync();

            return await FindByCondition(e => e.Name.Contains(name)).ToListAsync();
        }

        public async Task<IEnumerable<Entree>> GetEntreesByRestaurantAsync(int restaurantId)
        {
            return await FindAll().Include(m => m.Restaurant).Where(e => e.Restaurant.Id == restaurantId).ToListAsync();

            //return await FindByCondition(e => e.Restaurant.Id.Equals(restaurantId)).ToListAsync();
        }

        public Task<Entree> GetEntreeWithDetailsAsync(int entreeId)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Non-Async Methods
        public List<Entree> GetAllEntrees()
        {
            return FindAll().ToList();
        }

        public List<Entree> GetEntreesByName(string name)
        {
            if (name == null)
                return FindAll().OrderBy(e => e.Name).ToList();

            return FindByCondition(e => e.Name.Contains(name)).ToList();
        }

        public List<Entree> GetEntreesByRestaurant(int restaurantId)
        {
            return FindAll().Include(m => m.Restaurant).Where(e => e.Restaurant.Id == restaurantId).ToList();
        }

        public Entree GetEntreeById(int entreeId)
        {
            return FindByCondition(e => e.Id.Equals(entreeId)).Include(m => m.Restaurant).FirstOrDefault();
        }

        public Entree GetEntreeWithDetails(int entreeId)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region CRUD Methods
        public void UpdateEntree(Entree entree)
        {
            entree.Restaurant = RepositoryContext.Restaurants.SingleOrDefault(m => m.Id == entree.Restaurant.Id);
            Update(entree);
        }

        public void CreateEntree(Entree entree)
        {
            entree.Restaurant = RepositoryContext.Restaurants.SingleOrDefault(m => m.Id == entree.Restaurant.Id);
            Create(entree);
        }

        public void DeleteEntree(Entree entree)
        {
            Delete(entree);
        }

        #endregion

        #region Entree Review Section
        public List<EntreeReview> GetEntreeReviews(Entree entree)
        {
            return this.RepositoryContext.EntreeReviews.Where(r => r.ReviewedEntree.Id == entree.Id).Include(e => e.User).Include(e => e.ReviewedEntree).ToList();
        }

        #endregion
    }
}
