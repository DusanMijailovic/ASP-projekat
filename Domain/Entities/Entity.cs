﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public abstract class Entity
	{

		public int Id { get; set; }

		public DateTime CreatedAt { get; set; }
		public DateTime? ModifiedAt { get; set; }

		public bool IsActive { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime? DeletedAt { get; set; }
	}
}
