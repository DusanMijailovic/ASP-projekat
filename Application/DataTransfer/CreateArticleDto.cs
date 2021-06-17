using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
	public class CreateArticleDto
	{
		public string Headline { get; set; }
		public string Content { get; set; }
		public DateTime DateCreated { get; set; }
		public int CategoryId { get; set; }
		public int PhotoId { get; set; }

	
		public ICollection<TagArticleDto> TagArticlesDto { get; set; } = new List<TagArticleDto>();


	}
}
