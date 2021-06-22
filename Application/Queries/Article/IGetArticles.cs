using Application.DataTransfer;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.Article
{
	public interface IGetArticles : IQuery<PagedResponse<GetArticlesDto>, ArticleSearch >
	{
	}
}
