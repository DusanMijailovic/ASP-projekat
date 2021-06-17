using Application.Commands.User;
using Application.DataTransfer;
using Application.Exceptions;
using DataAccess;
using FluentValidation;
using Implementation.Validators.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Commands.User
{
	public class EfUpdateUser : IUpdateUser
	{

		private readonly SportskeContext _context;
		private readonly UpdateUserValidator _validator;

		public EfUpdateUser(SportskeContext context, UpdateUserValidator validator)
		{
			_context = context;
			_validator = validator;
		}

		public int Id => 20;

		public string Name => "Update user";

		public void Execute(UserDto request)
		{

            var user = _context.Users.Include(x => x.UserUseCases).FirstOrDefault(x => x.Id == request.Id);

            if (user == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Domain.Entities.User));
            }

            _validator.ValidateAndThrow(request);

            user.UserName = request.UserName;
            user.Email = request.Email;
            user.RoleId = request.RoleId;
           

         

            var useCasesForDelete = user.UserUseCases.Where(x => !request.UseCases.Contains(x.UseCaseId)).ToList();
            var useCasesForInsert = request.UseCases.Where(x => !user.UserUseCases.Select(x => x.UseCaseId).Contains(x)).ToList();

            foreach (var x in useCasesForDelete)
            {
                x.IsActive = false;
                x.IsDeleted = true;
                x.DeletedAt = DateTime.Now;
            }

            foreach (var useCaseId in useCasesForInsert)
            {
                user.UserUseCases.Add(new Domain.Entities.UseUserCase
                {
                    UseCaseId = useCaseId
                });
            }

            _context.SaveChanges();




        }
	}
}
