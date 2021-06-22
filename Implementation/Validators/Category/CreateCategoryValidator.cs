using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators.Category
{
	public class CreateCategoryValidator : AbstractValidator<CategoryDto>
	{
		private readonly SportskeContext _context;


		public CreateCategoryValidator(SportskeContext context)
		{
			_context = context;

			RuleFor(x => x.Name).NotEmpty().WithMessage("Category must not be empty").DependentRules(() =>
			{

				RuleFor(x => x.Name).Must(x =>
				{
					return !_context.Categories.Any(y => y.Name == x);
				}).WithMessage("This name is already taken.");

			});



		}


	}
}