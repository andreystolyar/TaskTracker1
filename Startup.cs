using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Configuration;
using TaskTracker.Context;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TaskTracker.Entity;
using TaskTracker.Repository;
using TaskTracker.Services;
using TaskTracker.Services.Interfaces;
using TaskTracker.Repository.Interfaces;

namespace TaskTracker
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MyDbContext>(options => options.UseSqlServer(_configuration.GetConnectionString("ConnectionString")));
            services
                .AddControllers()
                .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddScoped<IRepository<ProjectEntity>, Repository<ProjectEntity>>();
            services.AddScoped<IRepository<TaskEntity>, Repository<TaskEntity>>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ITaskService, TaskService>();

            // AutoMapper.
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            // Swagger
            services.AddSwaggerGen(c =>
            {
                var path = AppContext.BaseDirectory;
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TaskTracker", Version = "v1" });
                c.IncludeXmlComments(Path.Combine(path, "TaskTracker.xml"), true);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler("/error");

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "TaskTracker v1");
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
