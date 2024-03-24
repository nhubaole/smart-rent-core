using RoomService.Model;

namespace RoomService.Repository.Interface
{
    public interface IRoomRepository
    {
        Task<string> Insert(CreateRoomReq room);
        Task<string> Update(CreateRoomReq room, int id);
        Task<string> Delete(int id);
        Task<Model.Room> GetById(int id);
        Task<List<Model.Room>> GetAll();
    }
}
