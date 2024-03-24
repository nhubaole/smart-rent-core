﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RoomService.Database;
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
                    throw new Exception("Room not found");
                }
                return room;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<string> Insert(CreateRoomReq room)
        {
            try
            {
                var roomInsert = _mapper.Map<Model.Room>(room);
                var insertedRoom = _roomDbContext.Rooms.Add(roomInsert);
                await _roomDbContext.SaveChangesAsync();
                return insertedRoom.Entity.RoomId.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public Task<string> Update(CreateRoomReq room, int id)
        {
            throw new NotImplementedException();
        }

        public Task<string> Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
