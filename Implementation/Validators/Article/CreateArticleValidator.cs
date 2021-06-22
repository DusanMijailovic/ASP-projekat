using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators.Article
{
	public class CreateArticleValidator : AbstractValidator<CreateArticleDto>
	{
		private readonly SportskeContext _context;
		public CreateArticleValidator(SportskeContext context)
		{
			_context = context;

			RuleFor(x => x.Headline).NotEmpty().WithMessage("Headline must not be empty")
				.MinimumLength(3).WithMessage("Headline must contain more than 3 letters");
			RuleFor(x => x.Content).NotEmpty().WithMessage("Content must not be empty")
				.MinimumLength(5).WithMessage("Content must contain more than 5 letters");
			RuleFor(x => x.CategoryId).Must(x=> { return _context.Categories.Any(y => y.Id == x); }).WithMessage("Category doesn't exist.");
			RuleFor(x => x.PhotoId).Must(x => { return _context.Photos.Any(y => y.Id == x); }).WithMessage("Photo doesn't exist.");
			RuleForEach(x => x.TagArticlesDto).ChildRules(tags =>
			{
				tags.RuleFor(x => x.TagId).Must(x => { return _context.Tags.Any(y => y.Id == x); })
				.WithMessage("Tag  doesn't exist.");
			});


		}
	}
}
