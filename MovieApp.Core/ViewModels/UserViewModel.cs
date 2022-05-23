using System.ComponentModel;

namespace MovieApp.Core.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        [DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }

        public string Mail { get; set; }
        public string Password { get; set; }
    }
}