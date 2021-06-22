using Application.DataTransfer;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.Category
{
	public interface IGetCategories : IQuery<PagedResponse<CategoryDto>, CategorySearch>
	{
	}
}
