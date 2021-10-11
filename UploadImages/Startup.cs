using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UploadImages.ActionHandlers;
using UploadImages.Mappers;
using UploadImages.Models;
using UploadImages.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UploadImages.Authorization;

namespace UploadImages
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<UploadImagesContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("UploadImagesDb")));

            services
                .AddTransient<IAccountWriter, AccountWriterRepository>()
                .AddTransient<IPostWriterReader, PostWriterReaderRepository>()
                .AddTransient<ICommentWriter, CommentWriterRepository>();

            services.AddAutoMapper(typeof(DbEntityMappers));
            services.AddMediatR(typeof(CreateAccountHandler));
            services.AddApiVersioning();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<CustomAuthorizeHandler>();
            app.UseHttpsRedirection();
            
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
