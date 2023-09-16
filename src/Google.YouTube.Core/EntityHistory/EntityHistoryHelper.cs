using Google.YouTube.Qing;
using System;
using System.Linq;
using Abp.Organizations;
using Google.YouTube.Authorization.Roles;
using Google.YouTube.MultiTenancy;

namespace Google.YouTube.EntityHistory
{
    public static class EntityHistoryHelper
    {
        public const string EntityHistoryConfigurationName = "EntityHistory";

        public static readonly Type[] HostSideTrackedTypes =
        {
            typeof(Country),
            typeof(OrganizationUnit), typeof(Role), typeof(Tenant)
        };

        public static readonly Type[] TenantSideTrackedTypes =
        {
            typeof(Country),
            typeof(OrganizationUnit), typeof(Role)
        };

        public static readonly Type[] TrackedTypes =
            HostSideTrackedTypes
                .Concat(TenantSideTrackedTypes)
                .GroupBy(type => type.FullName)
                .Select(types => types.First())
                .ToArray();
    }
}