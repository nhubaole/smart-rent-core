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

        public async Task<List<Room>> GetAll()
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

        Task<RoomResponse> IRoomRepository.Delete(int id)
        {
            throw new NotImplementedException();
        }

        Task<Room> IRoomRepository.GetById(int id)
        {
            throw new NotImplementedException();
        }

        Task<Room> IRoomRepository.Insert(CreateRoomRequest room)
        {
            throw new NotImplementedException();
        }

        Task<Room> IRoomRepository.Update(CreateRoomRequest room)
        {
            throw new NotImplementedException();
        }
    }
}
