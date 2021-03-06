using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
using static Murat.WebApi.Utilities.AESstring;

namespace Murat.WebApi
{
    public class Startup
    {
        private readonly string OriginList = "http://localhost:4200;https://antaminka.com;https://antaminka.pe;http://antaminka.com;" +
            "http://antaminka.pe;http://antaminka.murat.pe;http://admin.antaminka.pe;https://www.antaminka.com;https://www.antaminka.pe;http://www.antaminka.com;" +
            "http://www.antaminka.pe;http://www.antaminka.murat.pe;http://www.admin.antaminka.pe";
        private readonly string OriginMurat = "_OriginPolicy";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            #region ENABLE CORS
            services.AddCors(options =>
            {
                options.AddPolicy(OriginMurat,
                    builder =>
                    {
                        builder.WithOrigins(OriginList.Split(";"))
                        .AllowCredentials()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
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
            DecryptAES(Configuration.GetConnectionString("Project")), Configuration
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

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(OriginMurat);
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
