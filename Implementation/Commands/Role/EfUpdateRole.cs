using Application.Commands.Role;
using Application.DataTransfer;
using Application.Exceptions;
using AutoMapper;
using DataAccess;
using FluentValidation;
using Implementation.Validators.Role;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.Role
{
	public class EfUpdateRole : IUpdateRole
	{
		private readonly SportskeContext _context;
		private readonly UpdateRoleValidator _validator;
		private readonly IMapper _mapper;

		public EfUpdateRole(SportskeContext context, UpdateRoleValidator validator, IMapper mapper)
		{
			_context = context;
			_validator = validator;
			_mapper = mapper;
		}

		public int Id => 10;

		public string Name => "Update role";

		public void Execute(RoleDto request)
		{
			var role = _context.Roles.Find(request.Id);

			if (role == null)
			{
				throw new EntityNotFoundException(request.Id, typeof(Domain.Entities.Role));
			}

			_validator.ValidateAndThrow(request);

			_mapper.Map(request, role);
			_context.SaveChanges();

		}
	}
}
