using AutoMapper;

namespace UserService.AutoMap

{
    public class ProfileAutoMapper : Profile
    {
        public ProfileAutoMapper()
        {
            CreateMap<Model.User, UpdateUser>().ReverseMap();
            CreateMap<Model.User, GetUserByIdRes>().ReverseMap();
        }
    }
}
