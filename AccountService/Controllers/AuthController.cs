using AccountService.Database;
using AccountService.Model;
using JwtAuthenticationManager;
using JwtAuthenticationManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RabbitMQHandler.Services.Interfaces;
using System.Security.Claims;

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
            _messageProducer.SendingMessage(user.UserName, "GetCurrentUser");
            return Ok(authResponse);
        }

        private Account? GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;

                return new Account
                {
                    UserName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value
                };
            }
            return null;
        }
    }
}
