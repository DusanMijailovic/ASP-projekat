using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
	public class ArticleSearch : PagedSearch
	{

		public string Headline { get; set; }
		public string? Content { get; set; }
		public DateTime? DateFrom { get; set; }
		public DateTime? DateTo { get; set; }

		public string? OrderBy { get; set; }


		public int? CategoryId { get; set; }

	}
}
