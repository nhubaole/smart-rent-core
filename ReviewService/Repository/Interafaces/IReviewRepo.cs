namespace ReviewService.Repository.Interafaces
{
    public interface IReviewRepo
    {
        Task<Model.Review> Insert(CreateReview review);
        Task<Model.Review> Update(CreateReview review, int id);
        Task<Model.Review> Delete(int id);
        Task<Model.Review> GetById(int id);
        Task<List<Model.Review>> GetAll();
    }
}
