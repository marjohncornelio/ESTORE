using ESTORE.Server.Models;
using ESTORE.Shared.DTO.User;

namespace ESTORE.Server.Services.DataServices
{
    public class DataService : IDataService
    {
        public AddressDTO CastToAddressDTO(Address address)
        {
            return new AddressDTO()
            {
                Street = address.Street,
                City = address.City,
                Barangay = address.Barangay,
                ZipCode = address.ZipCode,
                Country = address.Country,
            };
        }

        public Address CastToAddress(AddressDTO addressDTO)
        {
            return new Address()
            {
                Street = addressDTO.Street,
                City = addressDTO.City,
                Barangay = addressDTO.Barangay,
                ZipCode = addressDTO.ZipCode,
                Country = addressDTO.Country,
            };
        }

        public UserDetailsDTO CastToUserDetailsDTO(User user)
        {
            return new UserDetailsDTO()
            {
                FullName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                Role = user.Role,
                AvatarURL = user.AvatarURL,
                UserName = user.UserName,
                HomeAddress = CastToAddressDTO(user.HomeAddress)
            };
        }
    }
}
