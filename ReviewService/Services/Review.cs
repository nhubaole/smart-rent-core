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

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }
    }
}