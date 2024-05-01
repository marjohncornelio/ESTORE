
using ESTORE.Shared.Enum;
using System.Net;

namespace ESTORE.Shared.DTO.User
{
    public class RegisterDTO
    {
        public string FullName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
    }
}
