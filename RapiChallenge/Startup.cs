using Autofac;
using Autofac.Core.Lifetime;
using Autofac.Integration.Mvc;
using Microsoft.Owin;
using Owin;
using RapiChallenge.BusinessLogic;
using RapiChallenge.Services;
using System.Reflection;
using System.Web.Mvc;

[assembly: OwinStartup(typeof(RapiChallenge.Startup))]

namespace RapiChallenge
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            ConfigureIoC(app);
        }

        private void ConfigureIoC(IAppBuilder app)
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<UsuarioService>().As<IUsuarioService>().AsImplementedInterfaces().InstancePerLifetimeScope().PreserveExistingDefaults();
            builder.RegisterType<BusinessLogicUsuario>().As<IBusinessLogicUsuario>().AsImplementedInterfaces().InstancePerLifetimeScope().PreserveExistingDefaults();

            IContainer container = AutofacConfig(app, builder);
            app.UseAutofacMiddleware(container);
            var mvcResolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(mvcResolver);
        }

        private static IContainer AutofacConfig(IAppBuilder app, ContainerBuilder builder)
        {
            return builder.Build();
        }
    }
}
