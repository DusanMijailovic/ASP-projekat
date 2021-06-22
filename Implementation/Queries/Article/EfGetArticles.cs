using Application.DataTransfer;
using Application.Queries;
using Application.Queries.Article;
using Application.Searches;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries.Article
{
	public class EfGetArticles : IGetArticles
	{

		private readonly SportskeContext _context;

		public EfGetArticles(SportskeContext context)
		{
			_context = context;
		}

		public int Id => 22;

		public string Name => "Get articles";

		public PagedResponse<GetArticlesDto> Execute(ArticleSearch search)
		{
			var article = _context.Articles.Include(x => x.Comments).Include(x => x.TagArticles).Include(x => x.Categories).Include(x => x.Photos).AsQueryable();

			if (!string.IsNullOrEmpty(search.Headline) || !string.IsNullOrWhiteSpace(search.Headline))
			{
				article = article.Where(x => x.Headline.ToLower().Contains(search.Headline.ToLower()));
			}

			if (!string.IsNullOrEmpty(search.Content) || !string.IsNullOrWhiteSpace(search.Content))
			{
				article = article.Where(x => x.Content.ToLower().Contains(search.Content.ToLower()));
			}
			if (search.DateFrom != null && search.DateFrom > search.DateTo)
			{
				article = article.Where(x => x.DatePosted >= search.DateFrom);
			}
			if (search.DateTo != null && search.DateTo > search.DateFrom)
			{
				article = article.Where(x => x.DatePosted <= search.DateTo);
			}
			if (search.CategoryId > 0)
			{
				article = article.Where(x => x.Categories.Id == search.CategoryId);
			}
			article = article.OrderByDescending(x => x.DatePosted);
			if (search.OrderBy == "asc")
			{
				article = article.OrderBy(x => x.DatePosted);
			}
			if (search.OrderBy == "desc")
			{
				article = article.OrderByDescending(x => x.DatePosted);
			}

			var skipCount = search.PerPage * (search.Page - 1);
			var post = new PagedResponse<GetArticlesDto>
			{
				CurrentPage = search.Page,
				ItemsPerPage = search.PerPage,
				TotalCount = article.Count(),
				Items = article.Skip(skipCount).Take(search.PerPage).Select(c => new GetArticlesDto
				{
					Id = c.Id,
					Headline = c.Headline,
					Content = c.Content,
					DatePosted = c.DatePosted,
					CategoryName = c.Categories.Name,
					Photo = c.Photos.Src,
					PhotoId = c.PhotoId,
					CategoryId = c.CategoryId,

					Comments = (ICollection<CommentsDto>)c.Comments.Select(x => new CommentsDto
					{
						Id = x.Id,
						Text = x.Text,
						UserName = x.Users.UserName,
						DateCreated = x.DateCreated
					}),
					TagsDto = (ICollection<TagsDto>)c.TagArticles.Select(v => new TagDto
					{
						Id = v.Tags.Id,
						Name = v.Tags.Name
						
					})

				}).ToList()


			};



			return post;




















		}
	}
}
