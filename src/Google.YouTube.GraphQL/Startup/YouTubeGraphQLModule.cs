using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Google.YouTube.Startup
{
    [DependsOn(typeof(YouTubeCoreModule))]
    public class YouTubeGraphQLModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(YouTubeGraphQLModule).GetAssembly());
        }

        public override void PreInitialize()
        {
            base.PreInitialize();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }
    }
}