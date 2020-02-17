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
        IEntreeReviewRespository entreeRepo;
        IRestaurantRepository restRepo;

        public SearchController(IEntreeReviewRespository _entreeRepo, IRestaurantRepository _restRepo)
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
        public IActionResult Review(int entreeId)
        {
            var vm = new ReviewEntreeVM
            {
                Entree = entreeRepo.GetEntreeById(entreeId),
            };

            vm.Reviews = entreeRepo.GetEntreeReviews(vm.Entree);

            return View(vm);
        }

        #region Ajax Methods

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
        public JsonResult OnActionEvent(string actionname, string id)
        {
            var pass = false;
            var exception = "";
            try
            {
                var entree = entreeRepo.GetEntreeById(int.Parse(id));

                switch (actionname)
                {
                    case "like":
                        entree.Likes += 1;
                        break;
                    case "dislike":
                        entree.Dislikes += 1;
                        break;
                    case "bookmark":
                        entree.Bookmarks += 1;
                        break;
                }

                entreeRepo.UpdateEntree(entree);
                pass = true;
                exception = "Action was successful";
            }
            catch(Exception ex)
            {
                exception = ex.ToString();
            }

            return new JsonResult(new Tuple<bool, string>(pass, exception));
        }
        #endregion
    }
}