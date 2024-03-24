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

        public override Task<APIResponse> Create(CreateRoomReq request, ServerCallContext context)
        {
            try
            {
                var room = _roomRepository.Insert(request);

                return Task.FromResult(new APIResponse
                {
                    StatusCode = 200,
                    CreatedRoomId = new CreateRoomRes { Id = room.Id }
                });
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Name is required."));
            }
        }
        public override async Task<APIResponse> GetAllRoom(Empty empty, ServerCallContext context)
        {
            var rooms = await _roomRepository.GetAll();
            var roomList = new RoomListResponse
            {
                //Rooms = new RoomListResponse.()
            };
            foreach (var room in rooms)
            {
                roomList.Rooms.Add(new Room
                {
                    Id = room.RoomId,
                    Title = room.Title,
                    Price = (float)room.Price,
                    Location = room.Location,
                });
            }
            return await Task.FromResult(new APIResponse
            {
                StatusCode = 200,
                Rooms = roomList
            });

        }
        public override async Task<APIResponse> GetRoomById(GetByIdReq req, ServerCallContext context)
        {
            var room = await _roomRepository.GetById(req.Id);
            var item = new GetByIdRes
            {
                Capacity = room.Capacity,
                Price = room.Price,
                ElectricityCost = room.ElectricityCost,
                InternetCost = room.InternetCost,
                Deposit = room.Deposit,
                Gender = room.Gender,
                Location = room.Location,
                RoomType = room.RoomType,
                WaterCost = room.WaterCost,
                Title = room.Title,
                HasParking = room.HasParking
            };
            return await Task.FromResult(new APIResponse
            {
                StatusCode = 200,
                Room = item
            });
        }
    }
}