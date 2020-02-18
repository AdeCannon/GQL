using FOA.GraphQL.Repositories;
using FOA.GraphQL.Repositories.GraphQL;
using FOA.GraphQL.Repositories.GraphQL.Types;
using FOA.GraphQL.Repositories.Repositories;
using FOA.WebApi.Extensions.HttpContext;
using FOA.WebApi.Extensions.Identity;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Exceptions;
using Swashbuckle.AspNetCore.Swagger;
using System;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace FOA.GraphQL.API
{
    /// <summary>
    /// Set up the web api
    /// </summary>
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private IHostingEnvironment CurrentEnvironment { get; set; }

        /// <summary>
        /// The Start up CTOR
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<GTPSContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:GtpsConnectionString"]));

            services.AddScoped<OrdersRepository>();
            services.AddScoped<AllocationsRepository>();
            services.AddScoped<AllocationsRepositoryUrl>();
            services.AddScoped<TransmissionsRepositoryUrl>();
            services.AddScoped<ControlRepportRepository>();
            services.AddScoped<OrdersRepositoryUrl>();

            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));

            services.AddScoped<TradingSchema>();
            services.AddScoped<TradingQuery>();
            services.AddScoped<MartinType>();
            services.AddScoped<OrderType>();
            services.AddScoped<OrderTypeUrl>();
            services.AddScoped<AllocationType>();
            services.AddScoped<AllocationTypeUrl>();
            services.AddScoped<TransmissionTypeUrl>();
            services.AddScoped<SameUserTradingType>();
            services.AddScoped<UnsolicitedTradingType>();
            services.AddScoped<BackFromTransferredType>();
            services.AddScoped<InputAuthSameUserType>();

            services.AddGraphQL(o => { o.ExposeExceptions = true; })
                .AddGraphTypes(ServiceLifetime.Scoped)
                .AddDataLoader();

            services.AddScoped(_ => IdentityProvider.GetUserIdentity(IdentityProvider.UserIdentityType.AutoDetect));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddLogging();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder
                        .WithOrigins(this.Configuration.GetValue<string>("AllowAddressList"))
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .SetPreflightMaxAge(new TimeSpan(1, 0, 0, 0))
                        .AllowCredentials());
            });

            // IISDefaults requires the following import:
            // using Microsoft.AspNetCore.Server.IISIntegration;
            services.AddAuthentication(IISDefaults.AuthenticationScheme);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Front Office GraphQL API - " + this.CurrentEnvironment.EnvironmentName.ToUpper(),
                    Description = "Front Office GraphQL API  -Swagger Documentation",
                    TermsOfService = "None",
                    Contact = new Contact() { Name = "Support", Email = "FOA.GraphQL.API_Support@GAM.Com", Url = "www.GAM.com" }
                });
            });

            services.AddSwaggerGen(c =>
            {
                c.IncludeXmlComments(GetXmlCommentsPath());
            });
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("AllowSpecificOrigin");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .Build();

            this.CurrentEnvironment = env;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseStaticFiles();

            // expose a static http context
            app.UseStaticHttpContext();

            app.UseGraphQL<TradingSchema>();

            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithThreadId()
                .Enrich.WithExceptionDetails()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            app.UseSwagger(o =>
            {
                o.RouteTemplate = "docs/{documentName}/docs.json";
            });

            app.UseSwaggerUI(c =>
            {
                c.InjectStylesheet("/swagger-ui/custom.css");
                c.RoutePrefix = "docs";
                c.SwaggerEndpoint("../docs/v1/docs.json", "API v1");
            });
        }

        private string GetXmlCommentsPath()
        {
            var app = System.AppContext.BaseDirectory;
            return System.IO.Path.Combine(app, "FOA.GraphQL.API.xml");
        }
    }
}
