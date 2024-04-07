using AccountService.Database;
using JwtAuthenticationManager;
using JwtAuthenticationManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AccountService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtTokenHandler _jwtTokenHandler;
        private readonly AccountDbContext _dbContext;
        public AuthController(JwtTokenHandler jwtTokenHandler, AccountDbContext dbContext)
        {
            _jwtTokenHandler = jwtTokenHandler;
            _dbContext = dbContext;
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
