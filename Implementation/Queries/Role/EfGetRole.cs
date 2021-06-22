using Application.DataTransfer;
using Application.Exceptions;
using Application.Queries.Role;
using AutoMapper;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Queries.Role
{
	public class EfGetRole : IGetRole
	{
		private readonly SportskeContext _context;
		private readonly IMapper _mapper;

		public EfGetRole(SportskeContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public int Id => 8;

		public string Name => "Get role";

		public RoleDto Execute(int search)
		{
			var role = _context.Roles.Find(search);

			if (role == null)
			{
				throw new EntityNotFoundException(search, typeof(Domain.Entities.Role));
			}

			return _mapper.Map<RoleDto>(role);

		}
	}
}
