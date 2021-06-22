using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators.Role
{
	public class UpdateRoleValidator : AbstractValidator<RoleDto>
	{
		private readonly SportskeContext _context;
		public UpdateRoleValidator(SportskeContext context)
		{
			_context = context;

			RuleFor(x => x.Name)
				.NotEmpty()
				.WithMessage("Role must not be empty").DependentRules(() =>
				{

					RuleFor(x => x.Name).Must((role, name) => !_context.Roles.Any(y => y.Name == name && y.Id != role.Id)).WithMessage("This name is already taken.");

				});




		}
	}
}
