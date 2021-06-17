using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
	public class GetArticleDto : BaseDto
	{
		public string Headline { get; set; }

		public string Content { get; set; }
		public string CategoryName { get; set; }
		public DateTime DateCreated { get; set; }
		public string Photo { get; set; }
		public int CategoryId { get; set; }
		public int PhotoId { get; set; }
		public int CountLikes { get; set; }

		
		public IEnumerable<CommentsDto> CommentsDto { get; set; } = new List<CommentsDto>();

		public IEnumerable<TagDto> TagsDto { get; set; } = new List<TagDto>();



	}
}
