using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Autofac;
using Barney.Infrastructure.Configuration;
using Barney.Infrastructure.DependencyInjection;
using Barney.WebUI.Infrastructure;
using Barney.WebUI.Infrastructure.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using CookieAuthenticationDefaults = Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults;
using log4net;
using log4net.Config;
using Mx.Library.Web.Logging.Middleware;
using Mx.Logging.Log4Net;

namespace Barney.WebUI
{
    public class Startup
    {
        private static string _keyVaultClientId;
        private static string _keyVaultKey;
        private const string ApplicationName = "Barney";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddControllersWithViews(config =>
            {
                var authorizationPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();

                config.Filters.Add(new AuthorizeFilter(authorizationPolicy));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            AddDataProtection(services);
            ConfigureAuthentication(services);

        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new CoreModule(new BarneyWebUIConfiguration(Configuration["UiConfiguration:DatabaseConnectionString"])));
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            
            app.UseCustomExceptionHandler(ApplicationName, "/home/error");
            
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }


        private void ConfigureAuthentication(IServiceCollection services)
        {
            services.AddAuthentication(sharedOptions =>
                {
                    sharedOptions.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    sharedOptions.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
                })
                .AddAzureAd(
                    options => Configuration.Bind("AzureAd", options)
                )
                .AddCookie();
        }


        private void AddDataProtection(IServiceCollection services)
        {
            
            _keyVaultClientId = Configuration["DataProtection:KeyVault:ClientId"];
            _keyVaultKey = Configuration["DataProtection:KeyVault:Secret"];
            
            var azureStorageConnectionString = Configuration["AzureStorage:ConnectionString"];
           
            var cloudStorage = CloudStorageAccount.Parse(azureStorageConnectionString);

            services.AddDataProtection()
                .PersistKeysToAzureBlobStorage(cloudStorage, Configuration["DataProtection:KeyStorage"])
                .ProtectKeysWithAzureKeyVault(new KeyVaultClient(GetToken), Configuration["DataProtection:KeyVault:KeyIdentifier"]);


        }

        private X509Certificate2 LoadCertificate()
        {
            var certificatePath = Configuration["DapiCertificatePath"];
            var certificatePassword = GetCertificatePassword();
            return CertificateStore.GetCertificate(certificatePath, certificatePassword);
        }

        private SecureString GetCertificatePassword()
        {
            var credential = new NetworkCredential("", Configuration["DapiProtectionCertificateKey"]);

            return credential.SecurePassword;
        }

        public static async Task<string> GetToken(string authority, string resource, string scope)
        {

            var authContext = new AuthenticationContext(authority);

            var credential = new ClientCredential(_keyVaultClientId, _keyVaultKey);
            var result = await authContext.AcquireTokenAsync(resource, credential).ConfigureAwait(continueOnCapturedContext: false);

            if (result == null)
            {
                throw new InvalidOperationException("Failed to obtain a token");
            }
            return result.AccessToken;
        }

    }
}
