using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
	public class CommentsDto : BaseDto
	{
		public string Text { get; set; }
		public DateTime DateCreated { get; set; }

		public string UserName { get; set; }

		

	}
}
