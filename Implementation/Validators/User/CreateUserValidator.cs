using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators.User
{
	public class CreateUserValidator : AbstractValidator<CreateUserDto>
	{
		private readonly SportskeContext _context;
		public CreateUserValidator(SportskeContext context)
		{
			_context = context;

            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("Username must not be empty!")
                .DependentRules(() =>
                {
                    RuleFor(x => x.UserName)
                        .Matches(@"^[\w\d]{3,}$")
                        .WithMessage("Username must have minimum 3 characters").DependentRules(() => {

                            RuleFor(x => x.UserName).Must(x =>
                            {
                                return !_context.Users.Any(y => y.UserName == x);
                            }).WithMessage("This name is already taken.");

                        });
                        
                        
                });

            RuleFor(x => x.Email).NotEmpty().EmailAddress().MinimumLength(5).Must(c => !_context.Users.Any(u => u.Email == c)).WithMessage("Email is already taken");

            RuleFor(x => x.Password)
               .NotEmpty()
               .WithMessage("Password must not be empty")
               .DependentRules(() =>
               {
                   RuleFor(x => x.Password)
                       .Matches(@"^[\w\d]{8,}$")
                       .WithMessage("Password must have minimum 8 characters");
               });

            RuleFor(x => x.RoleId)
                .Must(x => {
                    return _context.Roles.Any(y => y.Id == x && y.IsActive);
                })
                .WithMessage("This role does not exist.");



        }
	}
}
