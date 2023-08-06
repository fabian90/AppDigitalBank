
using monitoreo.Core.DTOs.Response;

namespace monitoreo.Core.Interfaces.Services
{
    public interface IAuthenticateService
    {
        UserAuthResponseDTO ValidateUser(string username, string password);
    }
}
