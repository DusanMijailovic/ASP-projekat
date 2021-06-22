using Application.DataTransfer;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.User
{
	public interface IGetUsers : IQuery<PagedResponse<UserDto>, UserSearch>
	{
	}
}
