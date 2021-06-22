using Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.Article
{
	public interface IGetArticle : IQuery<GetArticleDto, int>
	{
	}
}
