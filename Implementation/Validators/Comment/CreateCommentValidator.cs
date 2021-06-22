using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators.Comment
{
	public class CreateCommentValidator : AbstractValidator<CreateCommentDto>
	{

		private readonly SportskeContext _context;

		public CreateCommentValidator(SportskeContext context)
		{
			_context = context;

			RuleFor(x => x.ArticleId).Must(x=> { return _context.Articles.Any(y=>y.Id == x); }).WithMessage("Article  doesn't exist.");
			RuleFor(x => x.Text).NotEmpty().WithMessage("Comment is required");


		}
	}
}
