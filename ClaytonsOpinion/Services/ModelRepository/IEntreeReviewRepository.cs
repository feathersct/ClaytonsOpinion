using ClaytonsOpinion.Data.BizModels;
using ClaytonsOpinion.Services.InterfaceAndAbstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaytonsOpinion.Services.ModelRepository
{
    public interface IEntreeReviewRepository : IRepositoryBase<EntreeReview>
    {
        Task<IEnumerable<EntreeReview>> GetAllEntReviewsAsync();
        Task<EntreeReview> GetEntReviewByIdAsync(int entreeRevId);
        Task<EntreeReview> GetEntReviewWithDetailsAsync(int entreeRevId);

        List<EntreeReview> GetAllEntReviews();
        EntreeReview GetEntReviewById(int entreeRevId);
        EntreeReview GetEntReviewWithDetails(int entreeId);
        void CreateEntReview(EntreeReview entreeRev);
        void UpdateEntReview(EntreeReview entreeRev);
        void DeleteEntReview(EntreeReview entreeRev);
    }
}
