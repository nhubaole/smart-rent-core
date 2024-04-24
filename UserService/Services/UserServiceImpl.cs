using AutoMapper;
using Grpc.Core;
using UserService;
using UserService.Repository;

namespace UserService.Services
{
    public class UserServiceImpl : UserService.UserServiceBase
    {
        private readonly ILogger<UserServiceImpl> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserServiceImpl(ILogger<UserServiceImpl> logger, IUserRepository userRepository, IMapper mapper)
        {
            _logger = logger;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public override async Task<APIResponse> GetUserById(GetUserByIdReq request, ServerCallContext context)
        {
            var user = await _userRepository.GetById(request.Id);

            return await Task.FromResult(new APIResponse
            {
                StatusCode = 200,
                UserInfo = new GetUserByIdRes { 
                    UserName = user.UserName, 
                    FullName = user.FullName,
                    Avatar = user.Avatar, 
                    Dob = user.DOB.ToString(), 
                    Email = user.Email,  
                }
            });
        }

        public override async Task<APIResponse> UpdateUserInfo(UpdateUserInfoReq request, ServerCallContext context)
        {
            var user = await _userRepository.Update(request.UpdateUser, request.Id);

            return await Task.FromResult(new APIResponse
            {
                StatusCode = 200,
                UserId = new UpdateUserInfoRes
                {
                    UserId = user.UserId,
                }
            }) ;
        }

    }
}