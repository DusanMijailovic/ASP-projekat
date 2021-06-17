using Application.Commands.Role;
using Application.DataTransfer;
using AutoMapper;
using DataAccess;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.Role
{
	public class EfCreateRole : ICreateRole
	{

		private readonly SportskeContext _context;
		private readonly IMapper _mapper;
		private readonly CreateRoleValidator _validator;

		public EfCreateRole(SportskeContext context, IMapper mapper, CreateRoleValidator validator)
		{
			_context = context;
			_mapper = mapper;
			_validator = validator;
		}

		public int Id => 9;

		public string Name => "Create role";

		public void Execute(RoleDto request)
		{

			_validator.ValidateAndThrow(request);
			_context.Roles.Add(_mapper.Map<Domain.Entities.Role>(request));
			_context.SaveChanges();

		}
	}
}
