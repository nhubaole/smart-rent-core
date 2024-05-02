using ReviewService.Model;
using ReviewService.Repository.Interafaces;

namespace ReviewService.Repository.Impl
{
    public class ReviewRepo : IReviewRepo
    {
        public Task<Review> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Review>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Review> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Review> Insert(CreateReview review)
        {
            throw new NotImplementedException();
        }

        public Task<Review> Update(CreateReview review, int id)
        {
            throw new NotImplementedException();
        }
    }
}
