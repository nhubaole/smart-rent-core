using RoomService.Model;

namespace RoomService.Repository.Interface
{
    public interface IRoomRepository
    {
        Task<string> Insert(CreateRoomReq room);
        Task<string> Update(CreateRoomReq room, string id);
        Task<string> Delete(string id);
        Task<Model.Room> GetById(string id);
        Task<List<Model.Room>> GetAll();
    }
}
