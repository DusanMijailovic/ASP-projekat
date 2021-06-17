using Application.Commands.Comment;
using Application.DataTransfer;
using AutoMapper;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.Comment
{
	public class EfUpdateComment : IUpdateComment
	{

		private readonly SportskeContext _context;
		private readonly IMapper _mapper;

		public EfUpdateComment(SportskeContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public int Id => 30;

		public string Name => "Update comment";

		public void Execute(UpdateCommentDto request)
		{
			var comment = _context.Comments.Find(request.Id);

			_mapper.Map(request, comment);
			_context.SaveChanges();

		}
	}
}
