using ClaytonsOpinion.Data.BizModels;
using ClaytonsOpinion.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaytonsOpinion.Services
{
    public interface IOpinionRepository
    {
        #region Restaurants
        List<Restaurant> GetAllRestaurants();
        List<Restaurant> GetRestaurants(string zip, string name, RestaurantType type);
        Restaurant GetRestaurant(int id);
        bool UpdateRestaurant(Restaurant restaurant, int id = 0);
        bool DeleteRestaurant(int id);
        #endregion

        #region Entrees
        List<Entree> GetAllEntrees();
        List<Entree> GetEntrees(Restaurant restaurant);
        Entree GetEntree(int id);
        bool UpdateEntree(Entree entree, int id = 0);
        bool DeleteEntree(int id);
        #endregion
    }
}
