using User.Domain.Models.Response;

namespace User.Application.Services
{
    public interface IUserService
    {
        UserResponseDTO GetUser(int userId);
    }
}
