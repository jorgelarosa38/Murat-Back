using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Project.BusinessLogic.Implementations;
using Project.BusinessLogic.Interfaces;
using Project.DataAccess;
using Project.UnitOfWork;
using Project.BusinessLogic.Implements;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Project.BusinessLogic.Helpers;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace MuratProject
{
    public class Startup
    {
        private readonly string MyAllowedOrigin = "_MyOriginPolicy";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            #region ENABLE CORS
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowedOrigin,
                    builder =>
                    {
                        builder.WithOrigins(Configuration["AppSettings:AllowedOrigins"].Split(";")).AllowCredentials().AllowAnyMethod().AllowAnyHeader();
                    });
            });
            #endregion

            #region SECURITY SERVICES
            services.AddTransient<ISecurityLogic, SecurityLogic>();
            #endregion

            #region MAINTENCE SERVICES
            services.AddTransient<IUserLogic, UserLogic>();
            services.AddTransient<ITablaMaestraLogic, TablaMaestraLogic>();
            services.AddTransient<IComboLogic, ComboLogic>();
            services.AddTransient<IWriteOperationLogic, WriteOperationLogic>();
            services.AddTransient<IProductoLogic, ProductoLogic>();
            services.AddTransient<IMarcaLogic, MarcaLogic>();
            services.AddTransient<ISliderLogic, SliderLogic>();
            services.AddTransient<ICommonLogic, CommonLogic>();
            services.AddTransient<IPublicadoLogic, PublicadoLogic>();
            #endregion

            #region SQL CONNECTION
            services.AddSingleton<IUnitOfWork>(option => new ProjectUnitOfWork(
            Configuration.GetConnectionString("Project"), Configuration
            ));
            #endregion

            #region OAUTH 2.0
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddAuthorization(auth =>
            {
                auth.DefaultPolicy = new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build();
            });
            #endregion

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddMvcCore().AddAuthorization();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(MyAllowedOrigin);
            app.UseHttpsRedirection();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHsts();
            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
