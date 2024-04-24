using AutoMapper;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using UserService.Database;

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

        public async Task<Model.User> GetById(int id)
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

        public async Task<Model.User> Update(UpdateUser updateUser, int id)
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
