using Application.DataTransfer;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.Comment
{
	public interface IGetComments : IQuery<PagedResponse<CommentsDto>, CommentSearch>
	{
	}
}
