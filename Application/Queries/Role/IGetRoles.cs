using Application.DataTransfer;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.Role
{
	public interface IGetRoles : IQuery<PagedResponse<RoleDto>, RoleSearch>
	{
	}
}
