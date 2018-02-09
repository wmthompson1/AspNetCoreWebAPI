using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.IO;
using AspNetCoreWebAPI.Services;
using AspNetCoreWebAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using AutoMapper;
using Serilog;

namespace AspNetCoreWebAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true);

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            Configuration = builder.Build();

        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddLogging(loggingBuilder =>
            loggingBuilder.AddSerilog(dispose: true));
            
            services.AddDirectoryBrowser();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            //var conn = Configuration["connectionStrings:sqlConnection"];
            var conn = Configuration["connectionStrings:CCTSTSFContext"];
            
            services.AddDbContext<SqlDbContext>(options =>
                options.UseSqlServer(conn));

            services.AddScoped(typeof(IBookstoreRepository), typeof(BookstoreSqlRepository));
            //services.AddScoped(typeof(IBookstoreRepository), typeof(BookstoreMockRepository));
            services.AddScoped(typeof(IGenericEFRepository), typeof(GenericEFRepository));
            // William Thompson 1/15
            //services.AddScoped(typeof(ISurveyRepository), typeof(SurveyMockRepository));
            services.AddScoped(typeof(ISurveyRepository), typeof(SurveySqlRepository));
            // William Thompson 1/17
            services.AddScoped(typeof(IUserService), typeof(UserService));

            // v1 automapper

            //var config = new AutoMapper.MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile(new Models.AutoMapperProfileConfiguration());
            //});

            //var mapper = config.CreateMapper();
            //services.AddSingleton(mapper);

            
            services.AddMvc();

            //services.AddAutoMapper(); // <-- This is the line you add. // services.AddAutoMapper(typeof(Startup)); // <-- newer automapper version uses this signature.
            services.AddAutoMapper(typeof(Startup)); // <-- newer automapper version uses this signature.

            // CORS
            services.Configure<MvcOptions>(options =>
            {
                //options.Filters.Add(new CorsAuthorizationFilterFactory("AllowSpecificOrigin"));
                options.Filters.Add(new CorsAuthorizationFilterFactory("CorsPolicy"));

            });


            //AutoMapper.Mapper.Initialize(config =>
            //{
            //    config.CreateMap<Entities.Book, Models.BookDTO>();
            //    config.CreateMap<Models.BookDTO, Entities.Book>();
            //    config.CreateMap<Entities.Publisher, Models.PublisherDTO>();
            //    config.CreateMap<Models.PublisherDTO, Entities.Publisher>();
            //    config.CreateMap<Models.PublisherUpdateDTO, Entities.Publisher>();
            //    config.CreateMap<Entities.Publisher, Models.PublisherUpdateDTO>();
            //    config.CreateMap<Models.BookUpdateDTO, Entities.Book>();
            //    config.CreateMap<Entities.Book, Models.BookUpdateDTO>();

            //    // William Thompson
            //   // config.CreateMap<Entities.Survey, Models.SurveyDTO>();
            //   // config.CreateMap<Models.SurveyDTO, Entities.Survey>();

            //    // William Thompson
            //    config.CreateMap<Entities.User, Models.UserDTO>();
            //    config.CreateMap<Models.UserDTO, Entities.User>();
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        // logging update, William Thompson 1/15/2017 see program.cs
        // **NOTE: Serilog logging recommende getting rid of startup logging, but the logging init (2.0) is in main.

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
 

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseDirectoryBrowser();
            app.UseStatusCodePages();

            // Shows UseCors with CorsPolicyBuilder.
            app.UseCors("CorsPolicy");

            // Shows UseCors with CorsPolicyBuilder.
            app.UseCors(builder =>
               builder.WithOrigins("http://localhost:4200"));


            // IMPORTANT: Make sure UseCors() is called BEFORE this
            app.UseMvc();

            //app.Run(async (context) =>
            //{
            //    var message = Configuration["Message"];
            //    await context.Response.WriteAsync(message);
            //});
        }
    }
}
