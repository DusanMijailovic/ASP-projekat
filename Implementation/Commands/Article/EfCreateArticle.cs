using Application.Commands.Article;
using Application.DataTransfer;
using DataAccess;
using Domain.Entities;
using FluentValidation;
using Implementation.Validators.Article;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.Article
{
	public class EfCreateArticle : ICreateArticle
	{
		private readonly SportskeContext context;
		private readonly CreateArticleValidator _validator;

		public EfCreateArticle(SportskeContext context, CreateArticleValidator validator)
		{
			this.context = context;
			_validator = validator;
		}

		public int Id => 24;

		public string Name => "Create article";

		public void Execute(CreateArticleDto request)
		{
			_validator.ValidateAndThrow(request);


			var article = new Domain.Entities.Article
			{
				Content = request.Content,
				Headline = request.Headline,
				CategoryId = request.CategoryId,
				PhotoId = request.PhotoId,
				DatePosted = DateTime.Now
			};

			foreach (var tag in request.TagArticlesDto)
			{
				article.TagArticles.Add(new TagArticle
				{
					TagId = tag.TagId
				});



			}
			context.Add(article);
			context.SaveChanges();


		}
	}
}
