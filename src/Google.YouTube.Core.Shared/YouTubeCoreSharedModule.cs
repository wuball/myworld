using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Google.YouTube
{
    public class YouTubeCoreSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(YouTubeCoreSharedModule).GetAssembly());
        }
    }
}