using ClaytonsOpinion.Data.BizModels;
using ClaytonsOpinion.Services.InterfaceAndAbstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaytonsOpinion.Services.ModelRepository
{
    public interface IEntreeRespository : IRepositoryBase<Entree>
    {
        Task<IEnumerable<Entree>> GetAllEntreesAsync();
        Task<IEnumerable<Entree>> GetEntreesByNameAsync(string name);
        Task<IEnumerable<Entree>> GetEntreesByRestaurantAsync(int restaurantId);
        Task<Entree> GetEntreeByIdAsync(int entreeId);
        Task<Entree> GetEntreeWithDetailsAsync(int entreeId);
        void CreateEntree(Entree entree);
        void UpdateEntree(Entree entree);
        void DeleteEntree(Entree entree);
    }
}
