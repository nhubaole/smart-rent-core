using RoomService.Model;

namespace RoomService.Repository.Interface
{
    public interface IRoomRepository
    {
        Task<Model.Room> Insert(CreateRoomRequest room);
        Task<Model.Room> Update(CreateRoomRequest room);
        Task<RoomResponse> Delete(int id);
        Task<Model.Room> GetById(int id);
        Task<List<Model.Room>> GetAll();
    }
}
