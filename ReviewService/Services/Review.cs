using Grpc.Core;
using ReviewService;

namespace ReviewService.Services
{
    public class Review : ReviewService.ReviewServiceBase
    {
        private readonly ILogger<Review> _logger;
        public Review(ILogger<Review> logger)
        {
            _logger = logger;
        }

       
    }
}