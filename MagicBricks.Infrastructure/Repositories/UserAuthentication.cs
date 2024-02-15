using MagicBricks.Applications.Interfaces.IRepository;
using MagicBricks.Domain.Entities;
using MagicBricks.Domain.Entities.ViewModels;
using MagicBricks.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;

namespace MagicBricks.Infrastructure.Repositories
{
    public class UserAuthenticationRepository : IAuthenticationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _manager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserAuthenticationRepository(ApplicationDbContext context, UserManager<ApplicationUser> manager, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _manager = manager;
            _signInManager = signInManager;


        }

        public async Task<bool> RegisterUser(RegisterUserVm register)
        {
            {
                if (register == null) throw new ArgumentNullException(nameof(register));

                ApplicationUser user = new ApplicationUser()
                {
                    UserName = register.UserName,
                    PasswordHash = register.Password,
                    Email = register.Email
                };

                var newUser = await _manager.CreateAsync(user, user.PasswordHash);
                if (!newUser.Succeeded) return false;
                return true;

            }
        }

        public async Task<ApplicationUser> Login(SignUserVm login)
        {

            var checkUserInDb = await _manager.FindByNameAsync(login.Email);
            if (checkUserInDb == null) { return null; }
            var checkLogin = await _signInManager.CheckPasswordSignInAsync(checkUserInDb, login.Password, false);
            var applicationUser = _context.Users.FirstOrDefault(A => A.UserName == login.Email);
            return applicationUser;

        }
    }
}
