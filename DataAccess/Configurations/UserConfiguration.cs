using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configurations
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.Property(x => x.UserName).IsRequired().HasMaxLength(30); 
			builder.Property(x => x.Password).IsRequired().HasMaxLength(30);
			builder.HasIndex(x => x.UserName).IsUnique();
			builder.HasOne(x => x.Role)
				.WithMany(x => x.Users)
				.HasForeignKey(x => x.RoleId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasMany(x => x.Likes)
				.WithOne(x => x.Users)
				.HasForeignKey(x => x.UserId)
				.OnDelete(DeleteBehavior.Restrict);
			builder.HasMany(x => x.Favorites)
				.WithOne(x => x.Users)
				.HasForeignKey(x => x.UserId);
			builder.HasMany(x => x.Comments)
				.WithOne(x => x.Users)
				.HasForeignKey(x => x.UserId)
				.OnDelete(DeleteBehavior.Restrict);
			
			builder.HasMany(x => x.UserUseCases)
				.WithOne(x => x.Users)
				.HasForeignKey(x => x.UserId)
				.OnDelete(DeleteBehavior.Restrict);

		}
	}
}
