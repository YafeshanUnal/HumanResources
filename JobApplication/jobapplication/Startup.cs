using System.Reflection;
using jobapplication.Data.Database;
using jobapplication.Data.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace jobapplication
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

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "jobapplication", Version = "v1" });
            });

            services.AddMvc();
            services.AddControllers();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MsSQLConnection")));
            services.AddScoped<EfAdvertRepository>();
            services.AddScoped<EfBossRepository>();
            services.AddScoped<EfWorkerRepository>();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "jobapplication v1"));
            }

            app.UseHttpsRedirection();

            app.UseCors(options =>
             options.
             WithOrigins("http://localhost:3000")
             .AllowCredentials()
             .AllowAnyHeader()
             .AllowAnyMethod());

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
