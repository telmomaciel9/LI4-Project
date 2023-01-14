using System;
using Microsoft.AspNetCore.Identity;

namespace FeirasNovas.Data
{
	public class ApplicationUser: IdentityUser
	{
		public String Name { get; set; }
		public String Address { get; set; }
		public String? ProfilePic { get; set; }

	}
}

