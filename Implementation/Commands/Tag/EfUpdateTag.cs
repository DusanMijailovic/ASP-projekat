using Application.Commands.Tag;
using Application.DataTransfer;
using Application.Exceptions;
using AutoMapper;
using DataAccess;
using FluentValidation;
using Implementation.Validators.Tag;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.Tag
{
	public class EfUpdateTag : IUpdateTag
	{
		private readonly SportskeContext _context;
		private readonly UpdateTagValidator _validator;
		private readonly IMapper _mapper;

		public EfUpdateTag(SportskeContext context, UpdateTagValidator validator, IMapper mapper)
		{
			_context = context;
			_validator = validator;
			_mapper = mapper;
		}

		public int Id => 15;

		public string Name => "Update tag";

		public void Execute(TagDto request)
		{
			var role = _context.Tags.Find(request.Id);

			if (role == null)
			{
				throw new EntityNotFoundException(request.Id, typeof(Domain.Entities.Tag));
			}

			_validator.ValidateAndThrow(request);

			_mapper.Map(request, role);
			_context.SaveChanges();
		}
	}
}
