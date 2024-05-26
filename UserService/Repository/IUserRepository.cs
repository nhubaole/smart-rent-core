﻿namespace UserService.Repository
{
    public interface IUserRepository
    {
        Task<Model.User> Update(UpdateUser user, int id);
        //Task<Model.User> Delete(int id);
        Task<Model.User> GetById(int id);
        //Task<List<Model.User>> GetAll();

        Task<Model.User> GetByUserName(string userName);
        Task<Model.User> CreateUser(CreateUserReq req);
    }
}
