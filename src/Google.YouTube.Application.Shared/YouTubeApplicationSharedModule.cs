using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Google.YouTube
{
    [DependsOn(typeof(YouTubeCoreSharedModule))]
    public class YouTubeApplicationSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(YouTubeApplicationSharedModule).GetAssembly());
        }
    }
}