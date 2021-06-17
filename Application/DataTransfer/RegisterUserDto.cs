using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
	public class RegisterUserDto
	{
		public string Username { get; set; }
		public string Email { get; set; }
		public int RoleId { get; set; }

		public string Password { get; set; }
		public IEnumerable<UserCaseDto> UserCases { get; set; } 


	}
}
