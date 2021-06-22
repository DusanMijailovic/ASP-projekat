using Application.DataTransfer;
using Application.Queries;
using Application.Queries.Comment;
using Application.Searches;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries.Comment
{
	public class EfGetComments : IGetComments
	{

		private readonly SportskeContext _context;

		public EfGetComments(SportskeContext context)
		{
			_context = context;
		}

		public int Id => 27;

		public string Name => "Get comments";

		public PagedResponse<CommentsDto> Execute(CommentSearch search)
		{
			var comments = _context.Comments.Include(x => x.Articles).Include(x => x.Users).AsQueryable();

			if (!string.IsNullOrEmpty(search.UserName) || !string.IsNullOrWhiteSpace(search.UserName))
			{
				comments = comments.Where(c => c.Users.UserName.ToLower().Contains(search.UserName.ToLower()));
			}
			var skipCount = search.PerPage * (search.Page - 1);
			var comment = new PagedResponse<CommentsDto>
			{
				CurrentPage = search.Page,
				ItemsPerPage = search.PerPage,
				TotalCount = comments.Count(),
				Items = comments.Skip(skipCount).Take(search.PerPage).Select(c => new CommentsDto
				{
					Id = c.Id,
					Text = c.Text,
					DateCreated = c.DateCreated,
					UserName = c.Users.UserName



				}).ToList()
			};

			return comment;



		}
	}
}
