using ESTORE.Server.Data;
using ESTORE.Server.Services.DataServices;
using ESTORE.Shared.DTO.User;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static ESTORE.Server.Services.ServiceResponse.Response;

namespace ESTORE.Server.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor contextAccessor;
        private readonly DataContext context;
        private readonly IDataService dataService;

        public UserService(IHttpContextAccessor contextAccessor, DataContext context, IDataService dataService)
        {
            this.contextAccessor = contextAccessor;
            this.context = context;
            this.dataService = dataService;
        }

        public async Task<DataResponse<UserDetailsDTO>> GetAuthenticatedUserDetails()
        {
            if (contextAccessor.HttpContext != null)
            {
                var userId = contextAccessor.HttpContext.User.Claims.FirstOrDefault().Value;
                var user = await context.Users.Include(u => u.HomeAddress).FirstOrDefaultAsync(u => u.Id == int.Parse(userId));
                if (user != null)
                    return new DataResponse<UserDetailsDTO>(dataService.CastToUserDetailsDTO(user), "User Result");
                return new DataResponse<UserDetailsDTO>(null!, "User Result", HttpStatusCode.BadRequest);
            }
            return new DataResponse<UserDetailsDTO>(null!, "User Not Authenticated", HttpStatusCode.BadRequest);
        }
    }
}
