using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Google.YouTube
{
    [DependsOn(typeof(YouTubeXamarinSharedModule))]
    public class YouTubeXamarinAndroidModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(YouTubeXamarinAndroidModule).GetAssembly());
        }
    }
}