using API.Core;
using Application;
using Application.Commands;
using Application.Commands.Article;
using Application.Commands.Category;
using Application.Commands.Comment;
using Application.Commands.Like;
using Application.Commands.Photo;
using Application.Commands.Role;
using Application.Commands.Tag;
using Application.Commands.User;
using Application.Email;
using Application.Queries.Article;
using Application.Queries.Category;
using Application.Queries.Comment;
using Application.Queries.Photo;
using Application.Queries.Role;
using Application.Queries.Tag;
using Application.Queries.UseCaseLog;
using Application.Queries.User;
using DataAccess;
using Implementation.Commands;
using Implementation.Commands.Article;
using Implementation.Commands.Category;
using Implementation.Commands.Comment;
using Implementation.Commands.Like;
using Implementation.Commands.Photo;
using Implementation.Commands.Role;
using Implementation.Commands.Tag;
using Implementation.Commands.User;
using Implementation.Email;
using Implementation.Logging;
using Implementation.Profiles;
using Implementation.Queries;
using Implementation.Queries.Article;
using Implementation.Queries.Category;
using Implementation.Queries.Comment;
using Implementation.Commands.Like;
using Implementation.Queries.Photo;
using Implementation.Queries.Role;
using Implementation.Queries.Tag;
using Implementation.Queries.UseCaseLog;
using Implementation.Queries.User;
using Implementation.Validators;
using Implementation.Validators.Article;
using Implementation.Validators.Category;
using Implementation.Validators.Comment;
using Implementation.Validators.Role;
using Implementation.Validators.Tag;
using Implementation.Validators.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddTransient<SportskeContext>();
			
			services.AddTransient<JwtManager>();
			services.AddAutoMapper(typeof(CategoryProfile).Assembly);
			services.AddHttpContextAccessor();
			services.AddTransient<IGetCategories, EfGetCategories>();
			services.AddTransient<IGetCategory, EfGetCategory>();
			services.AddTransient<ICreateCategory, EfCreateCategory>();
			services.AddTransient<IDeleteCategory, EfDeleteCategory>();
			services.AddTransient<IUpdateCategory, EfUpdateCategory>();

			services.AddTransient<CreateCategoryValidator>();
			services.AddTransient<UpdateCategoryValidator>();
			services.AddTransient<RegisterUserValidator>();


			//roles
			services.AddTransient<IGetRoles, EfGetRoles>();
			services.AddTransient<IGetRole, EfGetRole>();
			services.AddTransient<ICreateRole, EfCreateRole>();
			services.AddTransient<IUpdateRole, EfUpdateRole>();
			services.AddTransient<IDeleteRole, EfDeleteRole>();

			services.AddTransient<CreateRoleValidator>();
			services.AddTransient<UpdateRoleValidator>();


			//tags
			services.AddTransient<IGetTags, EfGetTags>();
			services.AddTransient<IGetTag, EfGetTag>();
			services.AddTransient<ICreateTag, EfCreateTag>();
			services.AddTransient<IUpdateTag, EfUpdateTag>();
			services.AddTransient<IDeleteTag, EfDeleteTag>();

			services.AddTransient<CreateTagValidator>();
			services.AddTransient<UpdateTagValidator>();

			//users
			services.AddTransient<IGetUsers, EfGetUsers>();
			services.AddTransient<IGetUser, EfGetUser>();
			services.AddTransient<ICreateUser, EfCreateUser>();
			services.AddTransient<IUpdateUser, EfUpdateUser>();
			services.AddTransient<IDeleteUser, EfDeleteUser>();

			services.AddTransient<CreateUserValidator>();
			services.AddTransient<UpdateUserValidator>();

			//articles
			services.AddTransient<IGetArticles, EfGetArticles>();
			services.AddTransient<IGetArticle, EfGetArticle>();
			services.AddTransient<ICreateArticle, EfCreateArticle>();
			services.AddTransient<IUpdateArticle, EfUpdateArticle>();
			services.AddTransient<IDeleteArticle, EfDeleteArticle>();

			services.AddTransient<CreateArticleValidator>();
			services.AddTransient<UpdateArticleValidator>();

			//comments
			services.AddTransient<IGetComments, EfGetComments>();
			services.AddTransient<IGetComment, EfGetComment>();
			services.AddTransient<ICreateComment, EfCreateComment>();
			services.AddTransient<IUpdateComment, EfUpdateComment>();
			services.AddTransient<IDeleteComment, EfDeleteComment>();

			services.AddTransient<CreateCommentValidator>();


			//photos
			services.AddTransient<IGetPhoto, EfGetPhoto>();
			services.AddTransient<IDeletePhoto, EfDeletePhoto>();

			//usecaselog
			services.AddTransient<IGetUseCaseLog, EfGetUseCaseLog>();

			//likes
			services.AddTransient<ICreateLike, EfCreateLike>();
			services.AddTransient<IDeleteLike, EfDeleteLike>();


			services.AddTransient<IRegisterUserCommand, EfRegisterUser>();

			services.AddTransient<IUseCaseLogger, DatabaseUseCaseLogger>();
			services.AddTransient<IEmailSender, SmtpEmailSender>();
			services.AddTransient<UseCaseExecutor>();




			services.AddAuthentication(options =>
			{
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(cfg =>
			{
				cfg.RequireHttpsMetadata = false;
				cfg.SaveToken = true;
				cfg.TokenValidationParameters = new TokenValidationParameters
				{
					ValidIssuer = "asp_api",
					ValidateIssuer = true,
					ValidAudience = "Any",
					ValidateAudience = true,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsMyVerySecretKey")),
					ValidateIssuerSigningKey = true,
					ValidateLifetime = true,
					ClockSkew = TimeSpan.Zero
				};
			});




			services.AddTransient<IApplicationActor>(x =>
			{
				var accessor = x.GetService<IHttpContextAccessor>();


				var user = accessor.HttpContext.User;

				if (user.FindFirst("ActorData") == null)
				{
					return new AnonymusActor();
				}

				var actorString = user.FindFirst("ActorData").Value;

				var actor = JsonConvert.DeserializeObject<JwtActor>(actorString);

				return actor;

			});

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();
			app.UseStaticFiles();
			app.UseMiddleware<GlobalExceptionHandler>();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
