using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class TagArticle : Entity
	{

		public int TagId { get; set; }
		public virtual Tag Tags { get; set; }
		

		public int ArticleId { get; set; }
		public virtual Article	 Articles { get; set; }
	}
}
