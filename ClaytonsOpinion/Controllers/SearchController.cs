using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClaytonsOpinion.Services;
using ClaytonsOpinion.Services.ModelRepository;
using ClaytonsOpinion.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClaytonsOpinion.Controllers
{
    public class SearchController : Controller
    {
        IEntreeRespository entreeRepo;
        IRestaurantRepository restRepo;

        public SearchController(IEntreeRespository _entreeRepo, IRestaurantRepository _restRepo)
        {
            entreeRepo = _entreeRepo;
            restRepo = _restRepo;
        }

        public async Task<IActionResult> Index()
        {
            var vm = new SearchIndexVM();

            var restaurants = await restRepo.GetAllRestaurantsAsync();

            vm.Restaurants = new List<SelectListItem>();
            foreach(var r in restaurants)
            {
                vm.Restaurants.Add(new SelectListItem { Text = r.Name, Value = r.Id.ToString() });
            }

            return View(vm);
        }

        [HttpGet]
        public async Task<JsonResult> OnGetEntrees(string name)
        {
            JsonResult result = null;
            var response = await entreeRepo.GetEntreesByNameAsync(name);
            result = new JsonResult(response);
            return Json(result.Value);
        }

        [HttpGet]
        public async Task<JsonResult> OnGetEntreesByRestaurant(string id)
        {
            JsonResult result = null;
            var response = await entreeRepo.GetEntreesByRestaurantAsync(int.Parse(id));
            result = new JsonResult(response);
            return Json(result.Value);
        }

        [HttpGet]
        public async Task<JsonResult> OnGetRestaurants()
        {
            JsonResult result = null;
            var response = await restRepo.GetAllRestaurantsAsync();
            result = new JsonResult(response);
            return Json(result.Value);
        }

        [HttpPost]
        public async void RecordActionOnEntree(string action)
        {
            switch(action)
            {
                case "Like":
                    break;
                case "Dislike":
                    break;
                case "Bookmark":
                    break;
            }
        }
    }
}