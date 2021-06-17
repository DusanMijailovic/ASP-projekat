using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
	public class GetArticlesDto : BaseDto
	{
		public string Headline { get; set; }

		public string Content { get; set; }
		public DateTime DatePosted { get; set; }
		public string Photo { get; set; }
		public string CategoryName { get; set; }
		public int CategoryId { get; set; }
		public int PhotoId { get; set; }

		public virtual ICollection<TagsDto> TagsDto { get; set; } = new List<TagsDto>();

		public virtual ICollection<CommentsDto> Comments { get; set; } = new List<CommentsDto>();

	}
}
