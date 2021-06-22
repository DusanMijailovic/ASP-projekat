using Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.Comment
{
	public interface IGetComment : IQuery<CommentsDto, int >
	{
	}
}
