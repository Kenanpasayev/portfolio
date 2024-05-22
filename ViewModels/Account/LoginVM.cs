using System.ComponentModel.DataAnnotations;

namespace WebApplication15.ViewModels.Account
{
    public class LoginVM
    {
        public string Name { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
