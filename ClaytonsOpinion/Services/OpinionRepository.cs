using ClaytonsOpinion.Data;
using ClaytonsOpinion.Data.BizModels;
using ClaytonsOpinion.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaytonsOpinion.Services
{
    public class OpinionRepository : IOpinionRepository
    {
        private ApplicationDbContext _context;

        public OpinionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Restaurants
        /// <summary>
        /// Get all restaurants regardless of parameters. Should not be used if large amount of restaurants in database
        /// </summary>
        /// <returns></returns>
        public List<Restaurant> GetAllRestaurants()
        {
            return _context.Restaurants.ToList();
        }

        /// <summary>
        /// Get all restaurants that satisfies parameters
        /// </summary>
        /// <param name="zip">The zip that the user is located in.</param>
        /// <param name="name">The name of the restaurant. Does not have to be full name, just needs to be partial</param>
        /// <param name="type">Type of restaurant as shown in RestaurantType enum</param>
        /// <returns>List of restaurants that satisfies parameters</returns>
        public List<Restaurant> GetRestaurants(string zip, string name, RestaurantType type)
        {
            //TODO: make it to where it looks around the zip not for the actual zip itself && that only zip needs to not be null
            return _context.Restaurants.Where(r => r.ZipCode == zip && r.Name.Contains(name)).ToList();
        }

        /// <summary>
        /// Get Restaurant by database id
        /// </summary>
        /// <param name="id">database id</param>
        /// <returns></returns>
        public Restaurant GetRestaurant(int id)
        {
            return _context.Restaurants.SingleOrDefault(r => r.Id == id);
        }

        public bool UpdateRestaurant(Restaurant restaurant, int id = 0)
        {
            var ret = false;

            //TODO: Implement update functionality with logic already created from other apps

            return ret;
        }

        public bool DeleteRestaurant(int id)
        {
            var ret = false;

            //TODO: Implement delete functionality with logic already created from other apps

            return ret;
        }
        #endregion

        #region Entrees
        /// <summary>
        /// Gets all entrees regardless of criteria, should not be used if there are large amount of entrees in database.
        /// </summary>
        /// <returns></returns>
        public List<Entree> GetAllEntrees()
        {
            return _context.Entrees.ToList();
        }

        /// <summary>
        /// Gets entrees by restaurant
        /// </summary>
        /// <param name="restaurant">Restaurant to be searched for</param>
        /// <returns>List of entrees associated with the restaurant in parameter</returns>
        public List<Entree> GetEntrees(Restaurant restaurant)
        {
            return _context.Entrees.Where(e => e.Restaurant.Id == restaurant.Id).ToList();
        }

        /// <summary>
        /// Gets entree associated with id in database
        /// </summary>
        /// <param name="id">Id of entree in db</param>
        /// <returns>Entree with id associated in database</returns>
        public Entree GetEntree(int id)
        {
            return _context.Entrees.SingleOrDefault(e => e.Id == id);
        }

        public bool UpdateEntree(Entree entree, int id = 0)
        {
            var ret = false;

            //TODO: Implement update functionality with logic already created from other apps

            return ret;
        }

        public bool DeleteEntree(int id)
        {
            var ret = false;

            //TODO: Implement delete functionality with logic already created from other apps

            return ret;
        }
        #endregion
    }
}
