using Application;
using Application.Commands.Like;
using Application.DataTransfer;
using DataAccess;
using FluentValidation;

using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.Like
{

	public class EfCreateLike : ICreateLike
	{
		private readonly SportskeContext _context;
		private readonly IApplicationActor _actor;
		

		public EfCreateLike(SportskeContext context, IApplicationActor actor)
		{
			_context = context;
			_actor = actor;
			
		}

		public int Id => 35;

		public string Name => "Creating like";

		public void Execute(LikedDto request)

		{
			
			var like = new Domain.Entities.Like
			{
				UserId = _actor.Id,
				ArticleId = request.ArticleId
				
			};
			_context.Likes.Add(like);
			_context.SaveChanges();
		}
	}
}
