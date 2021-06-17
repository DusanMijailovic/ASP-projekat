using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class User : Entity
	{
		public string UserName { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
		public int RoleId { get; set; }


		public virtual Role Role { get; set; }

		public virtual ICollection<Like> Likes { get; set; } = new HashSet<Like>();

		public virtual ICollection<Favorite> Favorites { get; set; } = new HashSet<Favorite>();
		public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
		public virtual ICollection<UseUserCase> UserUseCases { get; set; } = new HashSet<UseUserCase>();

	}
}
