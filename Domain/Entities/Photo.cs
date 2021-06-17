using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class Photo : Entity
	{

		public string Src { get; set; }
		public string Alt { get; set; }
		public virtual ICollection<Article> Articles { get; set; }
	}
}
