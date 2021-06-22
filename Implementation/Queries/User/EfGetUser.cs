using Application.DataTransfer;
using Application.Exceptions;
using Application.Queries.User;
using AutoMapper;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries.User
{
	public class EfGetUser : IGetUser
	{
		private readonly SportskeContext _context;
		private readonly IMapper _mapper;

		public EfGetUser(SportskeContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public int Id => 18;

		public string Name => "Get user";

		public UserDto Execute(int search)
		{
			var user = _context.Users.Include(x => x.Role).Include(x => x.UserUseCases).FirstOrDefault(x => x.Id == search);

			if (user == null)
			{
				throw new EntityNotFoundException(search, typeof(Domain.Entities.User));
			}

			return _mapper.Map<UserDto>(user);


		}
	}
}
