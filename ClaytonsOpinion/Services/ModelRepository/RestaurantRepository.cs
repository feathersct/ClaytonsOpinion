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
    public class RestaurantRepository : RepositoryBase<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(ApplicationDbContext repositoryContext)
        : base(repositoryContext)
        {
        }

        #region Async Methods
        public async Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync()
        {
            return await FindAll()
            .OrderBy(r => r.Name)
            .ToListAsync();
        }

        public async Task<Restaurant> GetRestaurantByIdAsync(int restaurantId)
        {
            return await FindByCondition(r => r.Id.Equals(restaurantId)).FirstOrDefaultAsync();
        }

        public async Task<Restaurant> GetRestaurantWithDetailsAsync(int restaurantId)
        {
            return await FindByCondition(r => r.Id.Equals(restaurantId)).FirstOrDefaultAsync();
        }
        #endregion

        #region Non-Async Methods
        public Restaurant GetRestaurantById(int restaurantId)
        {
            return FindByCondition(r => r.Id.Equals(restaurantId)).FirstOrDefault();
        }
        #endregion

        #region CRUD Methods
        public void UpdateRestaurant(Restaurant restaurant)
        {
            Update(restaurant);
        }

        public void CreateRestaurant(Restaurant restaurant)
        {
            Create(restaurant);
        }

        public void DeleteRestaurant(Restaurant restaurant)
        {
            Delete(restaurant);
        }
        #endregion
    }
}
