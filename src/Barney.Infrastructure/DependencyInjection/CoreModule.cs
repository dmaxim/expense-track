using System;
using System.Reflection;
using Autofac;
using Barney.Business.Managers.Interfaces;
using Barney.Data.Contexts;
using Barney.Infrastructure.Configuration;
using Mx.EntityFramework.Contracts;
using Module = Autofac.Module;

namespace Barney.Infrastructure.DependencyInjection
{
    public class CoreModule : Module
    {

        private readonly BarneyWebUIConfiguration _webUiConfiguration;


        public CoreModule(BarneyWebUIConfiguration webUiConfiguration)
        {
            _webUiConfiguration = webUiConfiguration ?? throw new ArgumentNullException(nameof(webUiConfiguration));


        }

        protected override void Load(ContainerBuilder builder)
        {
            RegisterDataLayerDependencies(builder);

            RegisterBusinessLayerDependencies(builder);

        }

        private void RegisterDataLayerDependencies(ContainerBuilder builder)
        {
            builder.RegisterType<EntityContext>()
                .As<IEntityContext>()
                .WithParameter("connectionString", _webUiConfiguration.DatabaseConnectionString);

            var dataLayer = Assembly.GetAssembly(typeof(EntityContext));

            builder.RegisterAssemblyTypes(dataLayer)
                .Where(dataLayerType => dataLayerType.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();
        }

        private void RegisterBusinessLayerDependencies(ContainerBuilder builder)
        {
            var businessLayer = Assembly.GetAssembly(typeof(IIncomeManager));

            builder.RegisterAssemblyTypes(businessLayer)
                .Where(businessLayerType => businessLayerType.Name.EndsWith("Manager"))
                .AsImplementedInterfaces();
        }
    }
}
