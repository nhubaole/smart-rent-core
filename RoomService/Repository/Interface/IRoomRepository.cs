﻿using RoomService.Model;

namespace RoomService.Repository.Interface
{
    public interface IRoomRepository
    {
        Task<Model.Room> Insert(CreateRoomReq room);
        Task<Model.Room> Update(CreateRoomReq room, int id);
        Task<Model.Room> Delete(int id);
        Task<Model.Room> GetById(int id);
        Task<List<Model.Room>> GetAll();
    }
}
