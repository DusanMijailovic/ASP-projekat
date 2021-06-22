using Application.DataTransfer;
using Application.Queries;
using Application.Queries.User;
using Application.Searches;
using AutoMapper;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries.User
{
	public class EfGetUsers : IGetUsers
	{
		private readonly SportskeContext _context;
		private readonly IMapper _mapper;

		public EfGetUsers(SportskeContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public int Id => 17;

		public string Name => "Get users";

		public PagedResponse<UserDto> Execute(UserSearch search)
		{
			var users = _context.Users.Include(x => x.Role).AsQueryable();
			if (!string.IsNullOrEmpty(search.UserName) || !string.IsNullOrWhiteSpace(search.UserName))
			{
				users = users.Where(x => x.UserName.ToLower().Contains(search.UserName.ToLower()));
			}

			if (search.RoleId.HasValue)
			{
				users = users.Where(x => x.RoleId == search.RoleId.Value);
			}

			var skipCount = search.PerPage * (search.Page - 1);
			var user = new PagedResponse<UserDto>
			{
				CurrentPage = search.Page,
				ItemsPerPage = search.PerPage,
				TotalCount = users.Count(),
				Items = users.Skip(skipCount).Take(search.PerPage).Select(x => new UserDto
				{
					Id = x.Id,
					Email = x.Email,
					Password =x.Password,
					UserName = x.UserName,
					RoleId = x.Role.Id

				}).ToList()


			};
			return user;



		}
	}
}
