using Microsoft.AspNetCore.Identity;

namespace FeirasNovas.Data
{
    public class ApplicationUser : IdentityUser
    {
        public String Username { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public int Phone_Number { get; set; }
        public String Email { get; set; }
        public String? ProfilePic { get; set; }

    }
}