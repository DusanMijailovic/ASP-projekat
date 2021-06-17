using Application;
using Application.Commands.Comment;
using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using Implementation.Validators.Comment;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.Comment
{
	public class EfCreateComment : ICreateComment
	{

		private readonly SportskeContext _context;
		private readonly IApplicationActor _actor;
		private readonly CreateCommentValidator _validator;

		public EfCreateComment(SportskeContext context, IApplicationActor actor, CreateCommentValidator validator)
		{
			_context = context;
			_actor = actor;
			_validator = validator;
		}

		public int Id => 29;

		public string Name => "Create comment";

		public void Execute(CreateCommentDto request)
		{
			_validator.ValidateAndThrow(request);
			var comments = new Domain.Entities.Comment
			{
				ArticleId = request.ArticleId,
				UserId = _actor.Id,
				Text = request.Text,
				DateCreated = DateTime.Now
			};
			_context.Comments.Add(comments);
			_context.SaveChanges();






		}
	}
}
