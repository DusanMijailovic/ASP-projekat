using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
	public class UserDto : BaseDto
	{
		public string UserName { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }

		public int RoleId { get; set; }

		public virtual ICollection<FavoriteDto> Favorites { get; set; } = new List<FavoriteDto>();
		public virtual ICollection<int> UseCases { get; set; } = new List<int>();

		public virtual RoleDto Role { get; set; }
	}
}
