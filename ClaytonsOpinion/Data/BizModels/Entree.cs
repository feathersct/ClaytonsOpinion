using ClaytonsOpinion.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClaytonsOpinion.Data.BizModels
{
    public class Entree
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Restaurant Restaurant { get; set; }
        public EntreeType Type { get; set; }
        public decimal Price { get; set; }
        public string PriceSymbols { get; set; } // i.e. $-cheap, $$-semi expensive, $$$-expensive, $$$$-really expensive
        public string Notes { get; set; }

        [DefaultValue(0)]
        public int Likes { get; set; }

        [DefaultValue(0)]
        public int Dislikes { get; set; }

        [DefaultValue(0)]
        public int Bookmarks { get; set; }

        public void CalculatePriceSymbols()
        {
            var symbols = "$";

            for (int i = 0; i < this.Price; i += 10)
            {
                symbols += "$";
            }

            this.PriceSymbols = symbols;
        }
    }
}
