using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class Category : Entity
	{

		public string Name { get; set; }

		public virtual ICollection<Article> Articles { get; set; } = new HashSet<Article>();
	}
}
