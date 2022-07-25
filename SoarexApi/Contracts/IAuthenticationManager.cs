using Entities.DataTransferObjects.Authentication;

namespace Contracts
{
    public interface IAuthenticationManager
    {
        Task<bool> ValidateUser(AuthenticationUpsertDto authenticationUpsertDto);
        Task<string> CreateToken();
    }
}
