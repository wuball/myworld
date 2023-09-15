using Abp.Modules;
using Google.YouTube.Test.Base;

namespace Google.YouTube.Tests
{
    [DependsOn(typeof(YouTubeTestBaseModule))]
    public class YouTubeTestModule : AbpModule
    {
       
    }
}
