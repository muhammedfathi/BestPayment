using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NaqdiBLL.IRepository;
using NaqdiBLL.Repository;
using NaqdiDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace NaqdiAPI
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
           
            services.AddDbContext<NakqdiAppContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("BestPayMent")));
            services.AddControllers();

            services.AddScoped<BestPaymentRepo<Banks>,BankRepo>();
            services.AddScoped<BestPaymentRepo<Company>,CompanyRepo>();
            services.AddScoped<BestPaymentRepo<Role>,RoleRepo>();
            services.AddScoped<BestPaymentRepo<Service>, ServiceRepo>();
            services.AddScoped<BestPaymentRepo<Provider>, ProviderRepo>();
            services.AddScoped<BestPaymentRepo<cases>, CasesRepo>();
            services.AddScoped<BestPaymentRepo<TUser>, UserRepo>();
            services.AddScoped<BestPaymentRepo<ChargeOperation>, ChargeOperationRepo>();
            services.AddScoped<BestPaymentRepo<AgentCommissions>,AgentCommissionRepo>();
            services.AddScoped<BestPaymentRepo<CasesCPS>, CasesCPSRepo>();
            services.AddScoped<BestPaymentRepo<UsersDeposit>, UserDepositeRepo>();
            services.AddScoped<BestPaymentRepo<Excute>, ExecuteRepo>();
            services.AddScoped<BestPaymentRepo<Execution_Response>,ExecutionRes_Repo>();
            services.AddScoped<BestPaymentRepo<GlobalConfigration>, GlobalConfigRepo>();
            services.AddScoped<BestPaymentRepo<Login_Information>, LoggginInfoRepo>();
            services.AddScoped<BestPaymentRepo<Log>, LogRepo>();

            services.AddScoped<BestPaymentRepo<PayMent_Cards>, PaymentCardRepo>();
            services.AddScoped<BestPaymentRepo<privilage>, PrivilageRepo>();
            services.AddScoped<BestPaymentRepo<ProvidersDeposit>, Provider_DepositeRepo>();
            services.AddScoped<BestPaymentRepo<Rol_PrivFT>, Role_PrivRepo>();
            services.AddScoped<BestPaymentRepo<CasesCPSField_Prov>,CasesCPSFieldRepo>();

            //services.AddScoped<BestPaymentRepo<CasesCPSField_Prov>, CasesCPSFieldRepo>();
            //services.AddScoped<BestPaymentRepo<CasesCPSField_Prov>, CasesCPSFieldRepo>();
            //services.AddScoped<BestPaymentRepo<CasesCPSField_Prov>, CasesCPSFieldRepo>();
            //services.AddScoped<BestPaymentRepo<CasesCPSField_Prov>, CasesCPSFieldRepo>();










            //services.AddControllers().Addnewtonsoft
            //       options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
