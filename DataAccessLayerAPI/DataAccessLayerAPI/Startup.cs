using AutoMapper;
using DataAccessLayerAPI.DAL.Models;
using DataAccessLayerAPI.Hellpers;
using DataAccessLayerAPI.Interfaces;
using DataAccessLayerAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayerAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:4200")
                                                          .AllowAnyHeader()
                                                          .AllowAnyMethod();
                                  });
            });
            services.AddControllers();
            services.AddSwaggerGen(options => options.SwaggerDoc("v1", new OpenApiInfo { Title = "FundingAcademic API", Version = "v1" }));

            services.AddDbContext<FundingAcademicDBContext>(
                options => options.UseSqlServer("Server= LAPTOP-AHSVVFSV\n;initial catalog= FundingAcademicDB;integrated security=True;"));
            services.AddTransient<ObjectsMapper, ObjectsMapper>();
            services.AddTransient<ProjectEditHellper, ProjectEditHellper>();

            services.AddTransient<DataAccessService>(s => new DataAccessService(
                s.GetRequiredService<FundingAcademicDBContext>(), s.GetRequiredService<ObjectsMapper>(),
                s.GetRequiredService<ProjectEditHellper>()));

            services
    .AddControllersWithViews()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.Converters.Add(new StringEnumConverter()));

            services.AddSwaggerGenNewtonsoftSupport();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "FundingAcademic API V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
