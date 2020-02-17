using ClaytonsOpinion.Data.BizModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaytonsOpinion.ViewModels
{
    public class ReviewEntreeVM
    {
        public Entree Entree { get; set; }
        public List<EntreeReview> Reviews { get; set; }
        public EntreeReview BlankReview { get; set; } = new EntreeReview();
    }
}
