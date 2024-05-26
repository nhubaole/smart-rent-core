using Grpc.Core;
using RoomService.Model;

namespace RoomService.Repository.Interface
{
    public interface IRoomRepository
    {
        Task<Model.Room> Insert(CreateRoomReq room, ServerCallContext context);
        Task<Model.Room> Update(CreateRoomReq room, int id);
        Task<Model.Room> Delete(int id);
        Task<Model.Room> GetById(int id);
        Task<PagingResponse<Model.Room>> GetAll(int index, int pageCount);
    }
}
