using Application.Commands.Article;
using Application.DataTransfer;
using Application.Exceptions;
using DataAccess;
using Domain.Entities;
using FluentValidation;
using Implementation.Validators.Article;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Commands.Article
{
	public class EfUpdateArticle : IUpdateArticle
	{
		private readonly SportskeContext context;
		private readonly UpdateArticleValidator _validator;

		public EfUpdateArticle(SportskeContext context, UpdateArticleValidator validator)
		{
			this.context = context;
			_validator = validator;
		}

		public int Id => 25;

		public string Name => "Update article";

		public void Execute(UpdateArticleDto request)
		{
			_validator.ValidateAndThrow(request);
			var article = context.Articles.Include(x => x.TagArticles).FirstOrDefault(x => x.Id == request.Id);
			if (article == null)
			{
				throw new EntityNotFoundException(request.Id, typeof(Domain.Entities.Article));
			}
			article.Headline = request.Headline;
			article.Content = request.Content;
			article.CategoryId = request.CategoryId;
			article.PhotoId = request.PhotoId;

			var TagDelete = article.TagArticles.Where(x => !request.TagArticles.Contains(x.TagId));
			foreach (var c in TagDelete)
			{
				c.IsActive = false;
				c.IsDeleted = true;
				c.DeletedAt = DateTime.Now;

			}
			var tagIds = article.TagArticles.Select(x => x.TagId);
			var TagInsert = request.TagArticles.Where(x => !tagIds.Contains(x));
			foreach (var tagid in TagInsert)
			{
				article.TagArticles.Add(new TagArticle
				{
					TagId = tagid
				});
			}

			context.SaveChanges();



		}
	}
}
