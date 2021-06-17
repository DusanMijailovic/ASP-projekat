using Application.Commands.Comment;
using Application.Exceptions;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.Comment
{
	public class EfDeleteComment : IDeleteComment
	{
		
		private readonly SportskeContext _context;

		public EfDeleteComment(SportskeContext context)
		{
			_context = context;
		}

		public int Id => 31;

		public string Name => "Delete comment";

		public void Execute(int request)
		{
			var comment = _context.Comments.Find(request);
			if (comment == null)
			{
				throw new EntityNotFoundException(request, typeof(Domain.Entities.Comment));
			}

			comment.DeletedAt = DateTime.Now;
			comment.IsDeleted = true;
			comment.IsActive = false;
			_context.SaveChanges();

		}
	}
}
