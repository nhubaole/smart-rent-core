using Grpc.Core;
using UserService;

namespace UserService.Services
{
    public class User : UserService.UserServiceBase
    {
        private readonly ILogger<User> _logger;
        public User(ILogger<User> logger)
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