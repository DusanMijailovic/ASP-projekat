using DataAccess.Configurations;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
	public class SportskeContext : DbContext
	{

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-5FSS91T\MSSQLSERVER01;Initial Catalog=Sportske;Integrated Security=True");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Favorite>().HasKey(x => new {x.UserId, x.ArticleId });
			modelBuilder.Entity<Like>().HasKey(x => new { x.UserId, x.ArticleId });
			modelBuilder.Entity<TagArticle>().HasKey(x => new { x.TagId, x.ArticleId });

			modelBuilder.ApplyConfiguration(new ArticleConfiguration());
			modelBuilder.ApplyConfiguration(new CategoryConfiguration());

			modelBuilder.ApplyConfiguration(new CommentConfiguration());

			modelBuilder.ApplyConfiguration(new FavoriteConfiguration());
			modelBuilder.ApplyConfiguration(new LikeConfiguration());
			modelBuilder.ApplyConfiguration(new PhotoConfiguration());
			modelBuilder.ApplyConfiguration(new RoleConfiguration());
			modelBuilder.ApplyConfiguration(new TagConfiguration());
			modelBuilder.ApplyConfiguration(new UserConfiguration());





		}

		public override int SaveChanges()
		{
			foreach (var entry in ChangeTracker.Entries())
			{
				if (entry.Entity is Entity e)
				{
					switch (entry.State)
					{
						case EntityState.Added:
							e.IsActive = true;
							e.CreatedAt = DateTime.Now;
							e.IsDeleted = false;
							e.ModifiedAt = null;
							e.DeletedAt = null;
							break;
						case EntityState.Modified:
							e.ModifiedAt = DateTime.Now;
							break;
					}
				}
			}

			return base.SaveChanges();
		}


		public virtual DbSet<Article> Articles { get; set; }
		public virtual DbSet<Category> Categories { get; set; }
		public virtual DbSet<Comment> Comments { get; set; }
		public virtual DbSet<Favorite> Favorites { get; set; }

		public virtual DbSet<Like> Likes { get; set; }
		public virtual DbSet<Photo> Photos { get; set; }

		public virtual DbSet<Role> Roles { get; set; }
		public virtual DbSet<Tag> Tags { get; set; }
		public virtual DbSet<TagArticle> TagArticles { get; set; }
		public virtual DbSet<User> Users { get; set; }
		public virtual DbSet<UseUserCase> UserUseCases { get; set; }

		public virtual DbSet<UseCaseLog> UseCaseLogs { get; set; }












	}

}
