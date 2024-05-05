using AutoMapper;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using RoomService.Database;
using RoomService.Helper;
using RoomService.Repository.Interface;

namespace RoomService.Repository.Impls
{
    public class RoomRepository : IRoomRepository
    {
        private readonly RoomDbContext _roomDbContext;
        private readonly IMapper _mapper;
        public RoomRepository(RoomDbContext roomDbContext, IMapper mapper)
        {
            _roomDbContext = roomDbContext;
            _mapper = mapper;
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

        public async Task<Model.Room> GetById(int id)
        {
            try
            {
                var room = await _roomDbContext.Rooms.FirstOrDefaultAsync(x => x.RoomId == id);
                if (room == null)
                {
                    throw new RpcException(new Status(StatusCode.NotFound, $"Room {id} not found"));
                }
                return room;

            }
            catch (RpcException ex)
            {
                throw ex;
            }
        }

        public async Task<Model.Room> Insert(CreateRoomReq room, ServerCallContext context)
        {
            var currentUserName = HttpContextExtension.GetCurrentUser(context);
            try
            {
                var roomInsert = _mapper.Map<Model.Room>(room);
                roomInsert.CreatedBy = currentUserName;

                await _roomDbContext.Rooms.AddAsync(roomInsert);
                await _roomDbContext.SaveChangesAsync();
                return roomInsert;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Model.Room> Update(CreateRoomReq room, int id)
        {
            try
            {
                var updateRoom = await _roomDbContext.Rooms.FirstOrDefaultAsync(x => x.RoomId == id);
                if (updateRoom == null)
                {
                    throw new RpcException(new Status(StatusCode.NotFound, $"Room {id} not found"));
                }

                _mapper.Map(room, updateRoom);
                await _roomDbContext.SaveChangesAsync();
                return updateRoom;

            }
            catch (RpcException ex)
            {
                throw ex;
            }
        }

        public async Task<Model.Room> Delete(int id)
        {
            try
            {
                var deleteRoom = await _roomDbContext.Rooms.FirstOrDefaultAsync(x => x.RoomId == id);
                if (deleteRoom == null)
                {
                    throw new RpcException(new Status(StatusCode.NotFound, $"Room {id} not found"));
                }
                _roomDbContext.Rooms.Remove(deleteRoom);
                await _roomDbContext.SaveChangesAsync();
                return deleteRoom;
            }
            catch (RpcException ex)
            {
                throw ex;
            }
        }

    }
}
