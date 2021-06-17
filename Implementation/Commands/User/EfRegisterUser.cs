using Application.Commands;
using Application.DataTransfer;
using Application.Email;
using AutoMapper;
using DataAccess;
using FluentValidation;
using Implementation.Validators.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.User
{
	public class EfRegisterUser : IRegisterUserCommand
	{

		private readonly SportskeContext _context;
		private readonly RegisterUserValidator _validator;
		private readonly IEmailSender _sender;
		private readonly IMapper _mapper;
		public EfRegisterUser(SportskeContext context, RegisterUserValidator validator, IEmailSender sender, IMapper mapper)
		{
			_context = context;
			_validator = validator;
			_sender = sender;
			_mapper = mapper;
		}

		public int Id => 6;

		public string Name => "User Registration";

		public void Execute(RegisterUserDto request)
		{
			_validator.ValidateAndThrow(request);

			var user = new Domain.Entities.User
			{
				UserName = request.Username,
				Password = request.Password,
				Email = request.Email,
				RoleId = 7
			};
			var lista = new List<int> { 4,5,12,13,22,23,27,28,32,35,36  }; //izmeniti brojeve
			foreach (var i in lista)
			{
				user.UserUseCases.Add(new Domain.Entities.UseUserCase
				{
					UseCaseId = i

				});
			}
			_context.Users.Add(user);
			_context.SaveChanges();
			_sender.Send(new SendEmailDto
			{
				Subject = "Registration",
				Content = "Successfull Registration ",
				SendTo = request.Email
			});










		}
	}
}
