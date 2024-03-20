using AutoMapper;

namespace RoomService.DTO
{
    public class ProfileAutoMapper : Profile
    {
        public ProfileAutoMapper()
        {
            CreateMap<Model.Room, CreateRoomReq>().ReverseMap();
        }
    }
}
