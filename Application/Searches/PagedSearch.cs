﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
	public abstract class PagedSearch
	{

		public int PerPage { get; set; } = 12;
		public int Page { get; set; } = 1;

	}
}
