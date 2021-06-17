using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configurations
{
	public class TagConfiguration : IEntityTypeConfiguration<Tag>
	{
		public void Configure(EntityTypeBuilder<Tag> builder)
		{
			builder.Property(x => x.Name).IsRequired().HasMaxLength(30);
			builder.HasIndex(x => x.Name).IsUnique();

			builder.HasMany(x => x.TagArticles)
				.WithOne(x => x.Tags)
				.HasForeignKey(x => x.TagId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
