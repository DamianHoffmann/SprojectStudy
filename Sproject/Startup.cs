
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace Sproject
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
       

            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddHttpContextAccessor();

            services.RegisterDatabase(Configuration.GetConnectionString("dbLink"))
                    .RegisterRepositories()
                    .RegisterApplicationControllers()
                    .RegisterServices()
                    .RegisterDomainEvents();

            services.AddOpenApiDocument(config => {
                config.PostProcess = document => {
                    document.Info.Version = "v1";
                    document.Info.Title = "EcoSCADA API";
                };
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options =>
                options.WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                        );
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseOpenApi();
            app.UseSwaggerUi3(cfg => { });
            app.UseMvc();


        }
    }
}
