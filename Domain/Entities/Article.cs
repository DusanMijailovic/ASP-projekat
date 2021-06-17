using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class Article : Entity
	{
		public string Headline { get; set; }

		public string Content { get; set; }
		public DateTime DatePosted { get; set; }
		
		public int CategoryId { get; set; }
		public int PhotoId { get; set; }

		public virtual Category Categories { get; set; }
		public virtual Photo Photos { get; set; }
		public virtual ICollection<TagArticle> TagArticles { get; set; } = new HashSet<TagArticle>();
		public virtual ICollection<Favorite> Favorites { get; set; } = new HashSet<Favorite>();

		public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
		public virtual ICollection<Like> Likes { get; set; } = new List<Like>();

	}
}
