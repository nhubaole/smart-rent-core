using AutoMapper;

namespace RoomService.AutoMap

{
    public class ProfileAutoMapper : Profile
    {
        public ProfileAutoMapper()
        {
            CreateMap<Model.Room, CreateRoomReq>().ReverseMap();
        }
    }
}
