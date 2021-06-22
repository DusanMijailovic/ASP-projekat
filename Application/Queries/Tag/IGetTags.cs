using Application.DataTransfer;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.Tag
{
	public interface IGetTags : IQuery<PagedResponse<TagDto>, TagSearch >
	{
	}
}
