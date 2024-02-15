using System.ComponentModel.DataAnnotations;

namespace MagicBricks.Domain.Entities.ViewModels
{
    public class SignUserVm
    {
        [Required]
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
