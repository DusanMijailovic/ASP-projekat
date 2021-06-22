using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
	public class UserSearch : PagedSearch
	{
		public string UserName { get; set; }
		public int? RoleId { get; set; }

	}
}
