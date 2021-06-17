using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
	public class UpdateArticleDto : BaseDto
	{
		public string Headline { get; set; }
		public string Content { get; set; }
		public int CategoryId { get; set; }
		public int PhotoId { get; set; }

		public ICollection<int> TagArticles { get; set; } = new List<int>();


	}
}
