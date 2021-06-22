using Application.DataTransfer;
using Application.Queries;
using Application.Queries.Role;
using Application.Searches;
using AutoMapper;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries.Role
{
	public class EfGetRoles : IGetRoles
	{

		private readonly SportskeContext _context;
		private readonly IMapper _mapper;

		public EfGetRoles(SportskeContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public int Id => 7;

		public string Name => "Get roles";

		public PagedResponse<RoleDto> Execute(RoleSearch search)
		{

			var query = _context.Roles.AsQueryable();

			if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
			{
				query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
			}

			
			var skipcount = search.PerPage * (search.Page - 1);


			var roles = new PagedResponse<RoleDto>
			{
				CurrentPage = search.Page,
				ItemsPerPage = search.PerPage,
				TotalCount = query.Count(),
				Items = query.Skip(skipcount).Take(search.PerPage).Select(x => new RoleDto
				{
					Id = x.Id,
					Name = x.Name
				})

			};


			return roles;














		}
	}
}
