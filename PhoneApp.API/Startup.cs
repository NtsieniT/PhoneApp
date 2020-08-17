using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PhoneApp.API.Data;
using PhoneApp.API.Data.Repositories;
using PhoneApp.API.Helpers;

namespace PhoneApp.API
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
            services.AddDbContext<DataContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //services.AddMvc().SetCompatibilityVersion(version: CompatibilityVersion.Version_3_0)
            //  .ConfigureApiBehaviorOptions(options =>
            //  {
            //      options.InvalidModelStateResponseFactory = actionContext => {

            //          return CustomErrorResponse(actionContext);
            //      };
            //  });
            services.AddCors();


            services.AddScoped<IPhonebookRepository, PhonebookRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseExceptionHandler(builder => builder.Run(async context => {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var error = context.Features.Get<IExceptionHandlerFeature>();
                if (error != null)
                {
                    context.Response.AddApplicationError(error.Error.Message);
                    await context.Response.WriteAsync(error.Error.Message);
                }
            }));
            //  app.UseHttpsRedirection();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        // Below method extracts model state errors and assigns to the properties of Custom class.    
        private BadRequestObjectResult CustomErrorResponse(ActionContext actionContext)
        {
            //BadRequestObjectResult is class found Microsoft.AspNetCore.Mvc and is inherited from ObjectResult.    
            //Rest code is linq.    
            return new BadRequestObjectResult(actionContext.ModelState
             .Where(modelError => modelError.Value.Errors.Count > 0)
             .Select(modelError => new Error
             {
                 ErrorField = modelError.Key,
                 ErrorDescription = modelError.Value.Errors.FirstOrDefault().ErrorMessage
             }).ToList());
        }
    }
}
