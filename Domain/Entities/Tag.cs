using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class Tag : Entity
	{
		public string Name { get; set; }


		public virtual ICollection<TagArticle> TagArticles { get; set; } = new HashSet<TagArticle>();
	}
}
