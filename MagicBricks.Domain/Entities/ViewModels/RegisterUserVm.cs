
using System.ComponentModel.DataAnnotations;

namespace MagicBricks.Domain.Entities.ViewModels
{
    public class RegisterUserVm
    {
        [Required, MaxLength(50)]
        public string UserName
        {
            get;
            set;
        }
        [Required, DataType(DataType.EmailAddress)]
        public string Email
        {
            get;
            set;
        }
        [Required, DataType(DataType.Password)]
        public string Password
        {
            get;
            set;
        }

    }
}

