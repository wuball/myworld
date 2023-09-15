using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Google.YouTube.Authorization;

namespace Google.YouTube
{
    /// <summary>
    /// Application layer module of the application.
    /// </summary>
    [DependsOn(
        typeof(YouTubeApplicationSharedModule),
        typeof(YouTubeCoreModule)
        )]
    public class YouTubeApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Adding authorization providers
            Configuration.Authorization.Providers.Add<AppAuthorizationProvider>();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(YouTubeApplicationModule).GetAssembly());
        }
    }
}