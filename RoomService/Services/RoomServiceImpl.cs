using AutoMapper;
using Grpc.Core;
using RabbitMQHandler.Services.Interfaces;
using RoomService.Repository.Interface;

namespace RoomService.Services
{
    public class RoomServiceImpl : RoomService.RoomServiceBase
    {
        private readonly ILogger<RoomServiceImpl> _logger;
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;
        private readonly IMessageConsumer _messageConsumer;
        public RoomServiceImpl(ILogger<RoomServiceImpl> logger, IRoomRepository roomRepository, IMapper mapper, IMessageConsumer message)
        {
            _logger = logger;
            _roomRepository = roomRepository;
            _mapper = mapper;
            _messageConsumer = message;
        }

        public override async Task<APIResponse> Create(CreateRoomReq request, ServerCallContext context)
        {
            //var message = _messageConsumer.ReceiveMessage("GetCurrentUser");
            var room = await _roomRepository.Insert(request);



            return await Task.FromResult(new APIResponse
            {
                StatusCode = 200,
                CreatedRoomId = new CreateRoomRes { Id = room.RoomId }
            });

        }
        public override async Task<APIResponse> GetAllRoom(Empty empty, ServerCallContext context)
        {
            var rooms = await _roomRepository.GetAll();
            var roomList = new RoomListResponse();
            // var currentUser = await _messageConsumer.ReceiveMessageAsync("GetCurrentUser");
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
            var item = _mapper.Map<GetByIdRes>(room);
            return await Task.FromResult(new APIResponse
            {
                StatusCode = 200,
                Room = item
            });
        }
        public override async Task<APIResponse> Update(UpdateRoomReq request, ServerCallContext context)
        {

            var roomUpdate = await _roomRepository.Update(request.UpdateRoom, request.UpdateRoomId);
            return await Task.FromResult(new APIResponse
            {
                StatusCode = 200,
                CreatedRoomId = new CreateRoomRes { Id = roomUpdate.RoomId }
            });
        }

        public override async Task<APIResponse> Delete(DeleteRoomReq request, ServerCallContext context)
        {

            var roomDelete = await _roomRepository.Delete(request.RoomId);
            return await Task.FromResult(new APIResponse
            {
                StatusCode = 200,
                CreatedRoomId = new CreateRoomRes { Id = roomDelete.RoomId }
            });
        }

    }
}