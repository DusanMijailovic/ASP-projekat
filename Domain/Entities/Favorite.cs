using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class Favorite : Entity
	{
		public int UserId { get; set; }

		public int ArticleId { get; set; }

		public virtual User Users { get; set; }

		public virtual Article Articles { get; set; }

	}
}
