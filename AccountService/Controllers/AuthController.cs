using AccountService.Database;
using JwtAuthenticationManager;
using JwtAuthenticationManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RabbitMQHandler.Services.Interfaces;

namespace AccountService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtTokenHandler _jwtTokenHandler;
        private readonly AccountDbContext _dbContext;
        private readonly IMessageProducer _messageProducer;
        public AuthController(JwtTokenHandler jwtTokenHandler, AccountDbContext dbContext, IMessageProducer messageProducer)
        {
            _jwtTokenHandler = jwtTokenHandler;
            _dbContext = dbContext;
            _messageProducer = messageProducer;
        }
        [HttpPost]
        public async Task<ActionResult<AuthenticationRes?>> Login(AuthenticationReq req)
        {
            var user = await _dbContext.Accounts.FirstOrDefaultAsync(x => x.UserName == req.UserName && x.Password == req.Password);
            if (user == null)
            {
                return Unauthorized();
            }
            var authResponse = _jwtTokenHandler.GenerateToken(req, user);
            if (authResponse == null) { return Unauthorized(); }
            return Ok(authResponse);
        }
    }
}
