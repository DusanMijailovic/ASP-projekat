using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class Comment : Entity
	{

		public string Text { get; set; }
		public DateTime DateCreated { get; set; }

		public int UserId { get; set; }

		public int ArticleId { get; set; }
		public User Users { get; set; }

		public Article Articles { get; set; }
		
	}
}
