using Application.Commands.Tag;
using Application.Exceptions;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Commands.Tag
{
	public class EfDeleteTag : IDeleteTag
	{

        private readonly SportskeContext _context;

		public EfDeleteTag(SportskeContext context)
		{
			_context = context;
		}

		public int Id => 16;

		public string Name => "Delete tag";

		public void Execute(int request)
		{
            var tag = _context.Tags.FirstOrDefault(x => x.Id == request);

            if (tag == null)
            {
                throw new EntityNotFoundException(request, typeof(Domain.Entities.Tag));
            }

           

            tag.IsActive = false;
            tag.IsDeleted = true;
            tag.DeletedAt = DateTime.Now;

            _context.SaveChanges();
        }
	}
}
