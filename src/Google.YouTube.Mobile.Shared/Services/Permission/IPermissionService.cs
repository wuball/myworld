namespace Google.YouTube.Services.Permission
{
    public interface IPermissionService
    {
        bool HasPermission(string key);
    }
}