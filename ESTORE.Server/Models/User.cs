using ESTORE.Shared.Enum;

namespace ESTORE.Server.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = Array.Empty<byte>();
        public byte[] PasswordSalt { get; set; } = Array.Empty<byte>();
        public long PhoneNumber { get; set; }
        public string Email { get; set; } = string.Empty;
        public AccRoles? Role { get; set; } = AccRoles.USER;
        public string AvatarURL { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public Address? HomeAddress { get; set; }
    }

}
