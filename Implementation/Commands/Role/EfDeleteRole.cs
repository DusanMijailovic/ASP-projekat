using Application.Commands.Role;
using Application.Exceptions;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Commands.Role
{
	public class EfDeleteRole : IDeleteRole
	{
        private readonly SportskeContext _context;

		public EfDeleteRole(SportskeContext context)
		{
			_context = context;
		}

		public int Id => 11;

		public string Name => "Delete role";

		public void Execute(int request)
		{
            var role = _context.Roles.Include(x => x.Users).FirstOrDefault(x => x.Id == request);

            if (role == null)
            {
                throw new EntityNotFoundException(request, typeof(Domain.Entities.Role));
            }

            if (role.Users.Count > 0)
            {
                throw new ConflictException("You can't delete this resource because it is used in the system");
            }

            role.IsActive = false;
            role.IsDeleted = true;
            role.DeletedAt = DateTime.Now;

            _context.SaveChanges();



        }
	}
}
