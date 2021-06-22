using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
	public class UseCaseLogSearch : PagedSearch
	{
		public string? UserName { get; set; }
		public string? Name { get; set; }
		public DateTime? DateFrom { get; set; }
		public DateTime? DateTo { get; set; }

	}
}
