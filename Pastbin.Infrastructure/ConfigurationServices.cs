using Amazon.S3;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pastbin.Application.Interfaces;
using Pastbin.Infrastructure.DataAccess;
using Pastbin.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pastbin.Infrastructure
{
    public static class ConfigurationServices
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Add Some services in infrastructure
            services.AddScoped<ICommentService,CommentService>();   
            services.AddScoped<IPostService,PostService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IFileService, FileService>();

            //Adding config for connect to s3 
            services.AddDefaultAWSOptions(configuration.GetAWSOptions());
            services.AddAWSService<IAmazonS3>();

            //Add db config
            services.AddDbContext<PastbinDbContext>(s => s.UseNpgsql(configuration.GetConnectionString("Default")));
        }
    }
}
