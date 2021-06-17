using Application.Commands.Like;
using Application.Exceptions;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.Like
{
	public class EfDeleteLike : IDeleteLike
	{
		private readonly SportskeContext _context;

		public EfDeleteLike(SportskeContext context)
		{
			_context = context;
		}

		public int Id => 36;

		public string Name => "Removing like";

		public void Execute(int request)
		{
			var like = _context.Likes.Find(request);
			if (like == null)
			{
				throw new EntityNotFoundException(request, typeof(Domain.Entities.Like));
			}
			like.DeletedAt = DateTime.Now;
			like.IsDeleted = true;
			like.IsActive = false;
			_context.SaveChanges();
		}
	}
}
