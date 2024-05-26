using AutoMapper;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using UserService.Database;
using UserService.Model;

namespace UserService.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _userDbContext;
        private readonly IMapper _mapper;
        public UserRepository(UserDbContext userDbContext, IMapper mapper)
        {
            _userDbContext = userDbContext;
            _mapper = mapper;
        }

        public async Task<User> CreateUser(CreateUserReq req)
        {
            try
            {
                var existingUser = await _userDbContext.Users.FirstOrDefaultAsync(x => x.UserName == req.UserName);
                if (existingUser != null)
                {
                    throw new RpcException(new Status(StatusCode.InvalidArgument, $"User {req.UserName} already exists."));
                }
                var user = _mapper.Map<User>(req);
                _userDbContext.Users.Add(user);
                await _userDbContext.SaveChangesAsync();
                return user;
            }
            catch (RpcException ex)
            {
                throw ex;
            }
        }

        public async Task<User> GetById(int id)
        {
            try
            {
                var user = await _userDbContext.Users.FirstOrDefaultAsync(x => x.UserId == id);
                if (user == null)
                {
                    throw new RpcException(new Status(StatusCode.NotFound, $"User {id} not found"));
                }
                return user;

            }
            catch (RpcException ex)
            {
                throw ex;
            }
        }

        public async Task<User> GetByUserName(string userName)
        {
            try
            {
                var user = await _userDbContext.Users.FirstOrDefaultAsync(x => x.UserName == userName);
                if (user == null)
                {
                    throw new RpcException(new Status(StatusCode.NotFound, $"User {userName} not found"));
                }

                return user;
            }
            catch (RpcException ex)
            {
                throw ex;
            }
        }

        public async Task<User> Update(UpdateUser updateUser, int id)
        {
            try
            {
                var user = await _userDbContext.Users.FirstOrDefaultAsync(x => x.UserId == id);
                if (user == null)
                {
                    throw new RpcException(new Status(StatusCode.NotFound, $"User {id} not found"));
                }

                _mapper.Map(updateUser, user);
                await _userDbContext.SaveChangesAsync();
                return user;
            }
            catch (RpcException ex)
            {
                throw ex;
            }
        }

    }
}
