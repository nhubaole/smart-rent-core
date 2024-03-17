using RoomService.Model;

namespace RoomService.Repository.Interface
{
    public interface IRoomRepository
    {
        Task<Room> Insert(CreateRoomRequest room);
        Task<Room> Update(CreateRoomRequest room);
        Task<RoomResponse> Delete(int id);
        Task<Room> GetById(int id);
        Task<List<Room>> GetAll();
    }
}
