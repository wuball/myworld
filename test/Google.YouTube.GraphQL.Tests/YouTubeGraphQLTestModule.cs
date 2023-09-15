using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Google.YouTube.Configure;
using Google.YouTube.Startup;
using Google.YouTube.Test.Base;

namespace Google.YouTube.GraphQL.Tests
{
    [DependsOn(
        typeof(YouTubeGraphQLModule),
        typeof(YouTubeTestBaseModule))]
    public class YouTubeGraphQLTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            IServiceCollection services = new ServiceCollection();
            
            services.AddAndConfigureGraphQL();

            WindsorRegistrationHelper.CreateServiceProvider(IocManager.IocContainer, services);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(YouTubeGraphQLTestModule).GetAssembly());
        }
    }
}