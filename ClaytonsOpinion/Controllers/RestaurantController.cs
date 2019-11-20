using ClaytonsOpinion.Services.ModelRepository;
using ClaytonsOpinion.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaytonsOpinion.Controllers
{
    public class RestaurantController : Controller
    {
        IEntreeRespository entreeRepo;
        IRestaurantRepository restRepo;

        public RestaurantController(IEntreeRespository _entreeRepo, IRestaurantRepository _restRepo)
        {
            entreeRepo = _entreeRepo;
            restRepo = _restRepo;
        }

        [Route("Restaurant/{restaurantId}")]
        [Route("Restaurant/View/{restaurantId}")]
        [HttpGet]
        public IActionResult View(int restaurantId)
        {
            var vm = new RestaurantViewModel();

            vm.Restaurant = restRepo.GetRestaurantById(restaurantId);
            vm.AssociatedEntrees = entreeRepo.GetEntreesByRestaurant(restaurantId);

            return View(vm);
        }

        [HttpPost]
        public IActionResult CreateNewEntree(RestaurantViewModel vm)
        {
            if (vm.BlankEntree.Name == null)
                return View("View", vm.Restaurant.Id); //TODO: change to return an error

            vm.BlankEntree.Restaurant = restRepo.GetRestaurantById(vm.Restaurant.Id);

            entreeRepo.CreateEntree(vm.BlankEntree);

            return View("View", vm.Restaurant.Id);
        }

    }
}
