using ClaytonsOpinion.Data.BizModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaytonsOpinion.ViewModels
{
    public class SearchIndexVM
    {

        public string SearchText { get; set; }
        public List<Entree> FeaturedEntrees { get; set; }
        public List<SelectListItem> Restaurants { get; set; }
        public SelectListItem SelectedRestaurant { get; set; }

    }
}
