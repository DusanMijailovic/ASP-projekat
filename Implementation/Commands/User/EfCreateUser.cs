using Application.Commands.User;
using Application.DataTransfer;
using AutoMapper;
using DataAccess;
using FluentValidation;
using Implementation.Validators.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.User
{
	public class EfCreateUser : ICreateUser
	{
		private readonly SportskeContext _context;
		private readonly IMapper _mapper;
		private readonly CreateUserValidator _validator;

		public EfCreateUser(SportskeContext context, IMapper mapper, CreateUserValidator validator)
		{
			_context = context;
			_mapper = mapper;
			_validator = validator;
		}

		public int Id => 19;

		public string Name => "Create user";

		public void Execute(CreateUserDto request)
		{
			_validator.ValidateAndThrow(request);

			var user = _mapper.Map<Domain.Entities.User>(request);
			

			_context.Users.Add(user);
			_context.SaveChanges();
		}
	}
}
