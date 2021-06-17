using Application.Commands.User;
using Application.Exceptions;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Commands.User
{
	public class EfDeleteUser : IDeleteUser
	{
		private readonly SportskeContext _context;

		public EfDeleteUser(SportskeContext context)
		{
			_context = context;
		}

		public int Id => 21 ;

		public string Name => "Delete user";

		public void Execute(int request)
		{
            var user = _context.Users.Include(x => x.UserUseCases).FirstOrDefault(x => x.Id == request);

            if (user == null)
            {
                throw new EntityNotFoundException(request, typeof(Domain.Entities.User));
            }


            user.DeletedAt = DateTime.Now;
            user.IsDeleted = true;
            user.IsActive = false;

            foreach (var x in user.UserUseCases)
            {
                x.DeletedAt = DateTime.Now;
                x.IsDeleted = true;
                x.IsActive = false;
            }

            _context.SaveChanges();


        }
	}
}
