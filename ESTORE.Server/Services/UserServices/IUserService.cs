using ESTORE.Shared.DTO.User;
using static ESTORE.Server.Services.ServiceResponse.Response;

namespace ESTORE.Server.Services.UserServices
{
    public interface IUserService
    {
        Task<DataResponse<UserDetailsDTO>> GetAuthenticatedUserDetails();

    }
}
