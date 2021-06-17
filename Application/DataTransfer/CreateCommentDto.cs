using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
	public class CreateCommentDto
	{
		public string Text { get; set; }
		public DateTime DateCreated { get; set; }

		public int UserId { get; set; }

		public int ArticleId { get; set; }

	}
}
