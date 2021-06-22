using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators.User
{
	public class RegisterUserValidator : AbstractValidator<RegisterUserDto>
	{
		private readonly SportskeContext _context;
		public RegisterUserValidator(SportskeContext context)
		{
			_context = context;

			RuleFor(x => x.Username).NotEmpty().MinimumLength(3).Must(x => !_context.Users.Any(u => u.UserName == x)).WithMessage("Username is already taken");
			RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required").MinimumLength(8);
			RuleFor(x => x.Email).NotEmpty().EmailAddress().MinimumLength(5).Must(c => !_context.Users.Any(u => u.Email == c)).WithMessage("Email is already taken");
		}

		
	}
}
