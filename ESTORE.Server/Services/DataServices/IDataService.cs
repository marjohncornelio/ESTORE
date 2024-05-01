using ESTORE.Server.Models;
using ESTORE.Shared.DTO.User;

namespace ESTORE.Server.Services.DataServices
{
    public interface IDataService
    {
        AddressDTO CastToAddressDTO(Address address);
        Address CastToAddress(AddressDTO addressDTO);
        UserDetailsDTO CastToUserDetailsDTO(User user);

    }
}
