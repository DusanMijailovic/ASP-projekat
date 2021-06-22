using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators.Tag
{
	public class CreateTagValidator : AbstractValidator<TagDto>
	{
		private readonly SportskeContext _context;
		public CreateTagValidator(SportskeContext context)
		{
			_context = context;

			RuleFor(x => x.Name).NotEmpty().WithMessage("Name can't be empty").DependentRules(() =>
			{

				RuleFor(x => x.Name).Must(x =>
				{
					return !_context.Tags.Any(y => y.Name == x);
				}).WithMessage("This name is already taken.");
			}
			
			
			
			);


		}
	}
}
