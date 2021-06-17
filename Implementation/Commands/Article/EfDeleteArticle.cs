using Application.Commands.Article;
using Application.Exceptions;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.Article
{
	public class EfDeleteArticle : IDeleteArticle
	{
		private readonly SportskeContext _context;

		public EfDeleteArticle(SportskeContext context)
		{
			_context = context;
		}

		public int Id => 26;

		public string Name => "Delete article";

		public void Execute(int request)
		{
			var tag = _context.Articles.Find(request);
			if (tag == null)
			{
				throw new EntityNotFoundException(request, typeof(Domain.Entities.Article));
			}
			tag.DeletedAt = DateTime.Now;
			tag.IsDeleted = true;
			tag.IsActive = false;
			_context.SaveChanges();

		}
	}
}
