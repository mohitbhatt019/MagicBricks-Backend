using MagicBricks.Domain.Entities;
using MagicBricks.Domain.Entities.ViewModels;

namespace MagicBricks.Applications.Interfaces.IRepository
{
    public interface IAuthenticationRepository
    {
        Task<bool> RegisterUser(RegisterUserVm register);

        Task<ApplicationUser> Login(SignUserVm signUserVm);
    }
}
