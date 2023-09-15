using Abp.Zero.Ldap.Authentication;
using Abp.Zero.Ldap.Configuration;
using Google.YouTube.Authorization.Users;
using Google.YouTube.MultiTenancy;

namespace Google.YouTube.Authorization.Ldap
{
    public class AppLdapAuthenticationSource : LdapAuthenticationSource<Tenant, User>
    {
        public AppLdapAuthenticationSource(ILdapSettings settings, IAbpZeroLdapModuleConfig ldapModuleConfig)
            : base(settings, ldapModuleConfig)
        {
        }
    }
}