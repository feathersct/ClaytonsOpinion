using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaytonsOpinion.Data.BizModels
{
    public class EntreeReview
    {
        public int Id { get; set; }
        public Entree ReviewedEntree { get; set; }
        public string Username { get; set; } //TODO: Eventually make this be a user
        public DateTime ReviewDateTime { get; set; }
        public string Comment { get; set; }

    }
}
