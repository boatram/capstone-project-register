using CapstoneProject.Repository.Model;
using CapstoneProject.Service;
using CapstoneProjectRegister.Web.Pages.Mapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneProjectRegister.Web
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
            services.AddRazorPages();
            services.AddScoped<LecturerService>();
            services.AddScoped<TopicOfLecturerService>();
            services.AddScoped<TopicService>();
            services.AddScoped<SemesterService>();
            services.AddScoped<GroupService>();
            services.AddScoped<StudentService>();
            services.AddScoped<StudentInGroupService>();
            services.AddScoped<StudentInSemesterService>();
            services.AddScoped<FirebaseStorageService>();
            services.AddDbContext<CapstoneProjectRegisterContext>(option => option.UseSqlServer(Configuration.GetConnectionString("CapstoneProjectRegisterDB")));
            services.AddAutoMapper(typeof(Mapping).Assembly);
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
