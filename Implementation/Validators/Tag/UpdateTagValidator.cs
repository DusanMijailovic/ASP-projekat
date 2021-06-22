using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators.Tag
{
	public class UpdateTagValidator : AbstractValidator<TagDto>
	{
		private readonly SportskeContext _context;
		public UpdateTagValidator(SportskeContext context)
		{
			_context = context;

			RuleFor(x => x.Name)
				.NotEmpty()
				.WithMessage("Tag mustn't be empty").DependentRules(() =>
				{

					RuleFor(x => x.Name).Must((tag, name) => !_context.Tags.Any(y => y.Name == name && y.Id != tag.Id)).WithMessage("This name is already taken.");

				});
		}
	}
}
