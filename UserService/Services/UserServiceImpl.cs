using AutoMapper;
using Grpc.Core;
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

        public override async Task<APIResponse> GetUserByUserName(GetUserByUserNameReq request, ServerCallContext context)
        {
            try
            {
                var user = await _userRepository.GetByUserName(request.UserName);
                return new APIResponse
                {
                    StatusCode = 200,
                    UserInfo = new GetUserByIdRes
                    {
                        UserName = user.UserName,
                        FullName = user.FullName,
                        Avatar = user.Avatar,
                        Dob = user.DOB.ToString(),
                        Email = user.Email,
                    }
                };
            }
            catch (Exception ex)
            {
                return new APIResponse
                {
                    StatusCode = 500,
                    Error = new Error
                    {
                        Message = ex.Message,
                    },
                };
            }
        }

        public override async Task<APIResponse> CreateUser(CreateUserReq request, ServerCallContext context)
        {
            try
            {
                var user = await _userRepository.CreateUser(request);
                return new APIResponse
                {
                    StatusCode = 200,
                    UserIdCreate = new CreateUserRes
                    {
                        UserId = user.UserId
                    }
                };
            }
            catch (Exception ex)
            {
                return new APIResponse
                {
                    StatusCode = 500,
                    Error = new Error
                    {
                        Message = ex.Message,
                    }
                };
            }
        }

        public override async Task<APIResponse> GetUserById(GetUserByIdReq request, ServerCallContext context)
        {
            try
            {
                var user = await _userRepository.GetById(request.Id);

                return new APIResponse
                {
                    StatusCode = 200,
                    UserInfo = new GetUserByIdRes
                    {
                        UserName = user.UserName,
                        FullName = user.FullName,
                        Avatar = user.Avatar,
                        Dob = user.DOB.ToString(),
                        Email = user.Email,
                    }
                };
            }
            catch (Exception ex)
            {
                return new APIResponse
                {
                    StatusCode = 500,
                    Error = new Error
                    {
                        Message = ex.Message,
                    }
                };
            }
        }

        public override async Task<APIResponse> UpdateUserInfo(UpdateUserInfoReq request, ServerCallContext context)
        {
            try
            {
                var user = await _userRepository.Update(request.UpdateUser, request.Id);

                return new APIResponse
                {
                    StatusCode = 200,
                    UserId = new UpdateUserInfoRes
                    {
                        UserId = user.UserId,
                    }
                };
            }
            catch (Exception ex)
            {
                return new APIResponse
                {
                    StatusCode = 500,
                    Error = new Error
                    {
                        Message = ex.Message,
                    }
                };
            }
        }

    }
}