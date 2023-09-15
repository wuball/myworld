using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Google.YouTube
{
    [DependsOn(typeof(YouTubeClientModule), typeof(AbpAutoMapperModule))]
    public class YouTubeXamarinSharedModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Localization.IsEnabled = false;
            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(YouTubeXamarinSharedModule).GetAssembly());
        }
    }
}