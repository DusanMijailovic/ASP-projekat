using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configurations
{
	public class PhotoConfiguration : IEntityTypeConfiguration<Photo>
	{
		public void Configure(EntityTypeBuilder<Photo> builder)
		{
			builder.Property(x => x.Src).IsRequired();

			builder.HasMany(c => c.Articles)
				.WithOne(x => x.Photos)
				.HasForeignKey(x => x.PhotoId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
