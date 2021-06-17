using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class UseUserCase : Entity
	{
		public int UserId { get; set; }
		public int UseCaseId { get; set; }

		public virtual User Users { get; set; }

	}
}
