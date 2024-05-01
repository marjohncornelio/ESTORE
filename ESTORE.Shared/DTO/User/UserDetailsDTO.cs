using ESTORE.Shared.Enum;
using System.Net;

namespace ESTORE.Shared.DTO.User
{
    public class UserDetailsDTO
    {
        public string FullName { get; set; } = string.Empty;
        public long PhoneNumber { get; set; }
        public string Email { get; set; } = string.Empty;
        public AccRoles? Role { get; set; } = AccRoles.USER;
        public string AvatarURL { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public AddressDTO? HomeAddress { get; set; }
    }
}
