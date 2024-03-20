using Microsoft.EntityFrameworkCore;
using RoomService.Data;
using RoomService.Repository.Interface;

namespace RoomService.Repository.Impls
{
    public class RoomRepository : IRoomRepository
    {
        private readonly RoomDbContext _roomDbContext;
        public RoomRepository(RoomDbContext roomDbContext)
        {
            _roomDbContext = roomDbContext;
        }

        public async Task<List<Model.Room>> GetAll()
        {
            try
            {
                var rooms = await _roomDbContext.Rooms.ToListAsync();
                return rooms;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public Task<Model.Room> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Model.Room> Insert(CreateRoomRequest room)
        {
            throw new NotImplementedException();
        }

        public Task<Model.Room> Update(CreateRoomRequest room)
        {
            throw new NotImplementedException();
        }

        Task<RoomResponse> IRoomRepository.Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
