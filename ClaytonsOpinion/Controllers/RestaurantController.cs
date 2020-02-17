using ClaytonsOpinion.Data.BizModels;
using ClaytonsOpinion.Services.ModelRepository;
using ClaytonsOpinion.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaytonsOpinion.Controllers
{
    public class RestaurantController : Controller
    {
        IEntreeReviewRespository entreeRepo;
        IRestaurantRepository restRepo;

        private readonly UserManager<ApplicationUser> _userManager;

        public RestaurantController(IEntreeReviewRespository _entreeRepo, IRestaurantRepository _restRepo, UserManager<ApplicationUser> userManager)
        {
            entreeRepo = _entreeRepo;
            restRepo = _restRepo;
            _userManager = userManager;
        }

        //[Route("Restaurant/{restaurantId}")]
        [Route("Restaurant/View/{restaurantId}")]
        [HttpGet]
        public IActionResult View(int restaurantId)
        {
            var vm = new RestaurantViewModel();

            vm.Restaurant = restRepo.GetRestaurantById(restaurantId);
            vm.AssociatedEntrees = entreeRepo.GetEntreesByRestaurant(restaurantId);

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> MyRestaurant()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            var restaurant = restRepo.FindByCondition(m => m.RestaurantOwner.Id == user.Id).SingleOrDefault();

            return Redirect($"View/{restaurant.Id}");
        }

        [HttpPost]
        public IActionResult CreateNewEntree(RestaurantViewModel vm)
        {
            if (vm.BlankEntree.Name == null)
                return Redirect($"View/{vm.Restaurant.Id}"); //TODO: change to return an error

            vm.BlankEntree.Restaurant = restRepo.GetRestaurantById(vm.Restaurant.Id);

            vm.BlankEntree.CalculatePriceSymbols();
            entreeRepo.CreateEntree(vm.BlankEntree);

            return Redirect($"View/{vm.Restaurant.Id}");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRestaurantVM vm)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            vm.Restaurant.RestaurantOwner = user;

            restRepo.Create(vm.Restaurant);

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var restaurant = restRepo.GetRestaurantById(id);

            return View(restaurant);
        }

        [HttpPost]
        public IActionResult Edit(Restaurant restaurant)
        {
            restRepo.UpdateRestaurant(restaurant);

            return View(restaurant);
        }

    }
}
