using System.Collections.Generic;
using MvvmHelpers;
using Google.YouTube.Models.NavigationMenu;

namespace Google.YouTube.Services.Navigation
{
    public interface IMenuProvider
    {
        ObservableRangeCollection<NavigationMenuItem> GetAuthorizedMenuItems(Dictionary<string, string> grantedPermissions);
    }
}