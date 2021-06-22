using Application.DataTransfer;
using Application.Queries.Comment;
using AutoMapper;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries.Comment
{
	public class EfGetComment : IGetComment
	{

		private readonly SportskeContext _context;
		private readonly IMapper _mapper;

		public EfGetComment(SportskeContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public int Id => 28;

		public string Name => "Get comment";

		public CommentsDto Execute(int search)
		{
			var comment = _context.Comments.Include(x => x.Users).FirstOrDefault(a => a.Id == search);
			return _mapper.Map<CommentsDto>(comment);

		}
	}
}
