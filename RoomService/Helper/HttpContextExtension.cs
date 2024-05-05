using Grpc.Core;
using System.IdentityModel.Tokens.Jwt;

namespace RoomService.Helper
{
    public class HttpContextExtension
    {
        public static string GetCurrentUser(ServerCallContext context)
        {
            string jwtToken = context.RequestHeaders.FirstOrDefault(x => x.Key == "authorization")?.Value;
            if (jwtToken != null)
            {

                jwtToken = jwtToken.StartsWith("Bearer ") ? jwtToken.Substring(7) : jwtToken;

                var handler = new JwtSecurityTokenHandler();
                var token = handler.ReadToken(jwtToken) as JwtSecurityToken;
                var userId = token?.Claims.FirstOrDefault(claim => claim.Type == "nameid")?.Value;

                return userId;
            }
            else
            {
                throw new RpcException(new Status(StatusCode.Unauthenticated, "Authorization token not found"));
            }
        }
    }
}
