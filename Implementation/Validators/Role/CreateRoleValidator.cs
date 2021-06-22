using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators
{
	public class CreateRoleValidator : AbstractValidator<RoleDto>
	{
		private readonly SportskeContext _context;
		public CreateRoleValidator(SportskeContext context)
		{
			_context = context;

			RuleFor(x => x.Name).NotEmpty().WithMessage("Role must not be empty").DependentRules(() =>
			{

				RuleFor(x => x.Name).Must(x =>
				{
					return !_context.Roles.Any(y => y.Name == x);
				}).WithMessage("This name is already taken.");

			});



		}
	}
}
