using ClaytonsOpinion.Data.BizModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaytonsOpinion.ViewModels
{
    public class RestaurantViewModel
    {
        public Restaurant Restaurant { get; set; }

        public List<Entree> AssociatedEntrees { get; set; }
        public Entree BlankEntree { get; set; } = new Entree();
    }
}
