using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Supermarket.Core.Models;
using SupermarketAPI.DAL.Database;
using SupermarketAPI.DAL.GenericRepository;
using SupermarketAPI.DataAccessLayer.IRepositories;
using SupermarketAPI.DataAccessLayer.Repositories;
using SupermarketAPI.Service;
using Supperket.BLL.Business;
using Supperket.BLL.IBusiness;
using System.Text;
using Newtonsoft.Json;

namespace SupermarketAPI
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
            services.AddCors();

            services.AddDbContext<MyDBContext>(item => item.UseSqlServer(Configuration.GetConnectionString("MySqlConnection")));
            //services.AddDbContext<ApplicationDbContext>(item => item.UseSqlServer(Configuration.GetConnectionString("MySqlConnection")));

            // configure strongly typed settings objects
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

            // configure DI for application services
            services.AddScoped<IUserService, UserService>();

            //Scoped for Business
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IEndOfShiftRepository, EndOfShiftRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IPurchaseBillRepository, PurchaseBillRepository>();
            services.AddScoped<IPurchaseBillDetailRepository, PurchaseBillDetailRepository>();
            services.AddScoped<ISaleBillRepository, SaleBillRepository>();
            services.AddScoped<ISaleBillDetailRepository, SaleBillDetailRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<IStaffRepository, StaffRepository>();

            //Scoped for Resositories
            services.AddScoped<ICategoryBusiness, CategoryBusiness>();
            services.AddScoped<IEndOfShiftBusiness, EndOfShiftBusiness>();
            services.AddScoped<IProductBusiness, ProductBusiness>();
            services.AddScoped<IPurchaseBillBusiness, PurchaseBillBusiness>();
            services.AddScoped<ISaleBillBusiness, SaleBillBusiness>();
            services.AddScoped<IStatisticsBusiness, StatisticsBusiness>();
            services.AddScoped<ISupplierBusiness, SupplierBusiness>();
            services.AddScoped<IStaffBusiness, StaffBusiness>();

            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            //services.AddScoped<IStaffService, StaffService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
