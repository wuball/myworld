using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Google.YouTube
{
    public class YouTubeClientModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(YouTubeClientModule).GetAssembly());
        }
    }
}
