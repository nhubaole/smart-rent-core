using Google.Protobuf.Collections;
using Grpc.Core;
using Microsoft.AspNetCore.Mvc;
using RoomService;
using RoomService.Repository.Interface;

namespace RoomService.Services
{
    public class RoomServiceImpl : RoomService.RoomServiceBase
    {
        private readonly ILogger<RoomServiceImpl> _logger;
        private readonly IRoomRepository _roomRepository;
        public RoomServiceImpl(ILogger<RoomServiceImpl> logger, IRoomRepository roomRepository)
        {
            _logger = logger;
            _roomRepository = roomRepository;
        }

        public override Task<RoomResponse> Create(CreateRoomRequest request, ServerCallContext context)
        {
            return Task.FromResult(new RoomResponse
            {
                ErrorCode = "00",
                Result = new RoomResponse.Types.Result { Id = "11" }
            });
        }
        public override async Task<RoomListResponse> GetAllRoom(Empty empty, ServerCallContext context)
        {
            var rooms = await _roomRepository.GetAll();
            var roomList = new RoomListResponse
            {
                Result = new RoomListResponse.Types.Result()
            };
            foreach (var room in rooms)
            {
                roomList.Result.Rooms.Add(new Room
                {
                    Id = room.Id,
                    Title = room.Title,
                    Price = room.Price,
                    Location = room.Location,
                });
            }
            return await Task.FromResult(new RoomListResponse
            {
                ErrorCode = "00",
                Result = roomList.Result
            });
        }
    }
}