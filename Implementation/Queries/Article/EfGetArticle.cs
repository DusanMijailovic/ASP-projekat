using Application.DataTransfer;
using Application.Exceptions;
using Application.Queries.Article;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries.Article
{
	public class EfGetArticle : IGetArticle
	{

		private readonly SportskeContext _context;

		public EfGetArticle(SportskeContext context)
		{
			_context = context;
		}

		public int Id => 23;

		public string Name => "Get article";

		public GetArticleDto Execute(int search)
		{
			var article = _context.Articles.Include(x => x.Comments).ThenInclude(x => x.Users).Include(x => x.TagArticles).ThenInclude(x => x.Tags)
				.Include(x => x.Photos).Include(x => x.Categories).Include(x => x.Likes).FirstOrDefault(a => a.Id == search);
			if (article == null)
			{
				throw new EntityNotFoundException(search, typeof(Domain.Entities.Article));
			}

			
			return new GetArticleDto
			{

				Id = article.Id,
				Headline = article.Headline,
				Content = article.Content,
				DateCreated = DateTime.Now,
				CategoryName = article.Categories.Name,
				Photo = article.Photos.Src,
				PhotoId = article.PhotoId,
				CategoryId = article.CategoryId,
				
				CountLikes = article.Likes.Count(),

				CommentsDto = article.Comments.Select(x => new CommentsDto
				{
					Id = x.Id,
					Text = x.Text,
					UserName = x.Users.UserName,
					DateCreated = x.DateCreated
				}).ToList(),
				TagsDto = article.TagArticles.Select(v => new TagDto
				{
					Name = v.Tags.Name,
					Id = v.Tags.Id
				}).ToList()


			};


		}
	}
}
