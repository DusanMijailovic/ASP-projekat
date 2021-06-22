using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators.Category
{
	public class UpdateCategoryValidator : AbstractValidator<CategoryDto>
	{
		private readonly SportskeContext _context;
		public UpdateCategoryValidator(SportskeContext context)
		{
			_context = context;

			RuleFor(x => x.Name)
				.NotEmpty()
				.WithMessage("Category mustn't be empty").DependentRules(() =>
				{

					RuleFor(x => x.Name).Must((cat,name) => !_context.Categories.Any(y => y.Name == name && y.Id != cat.Id)).WithMessage("This name is already taken.");

				});



		}
	}
}
