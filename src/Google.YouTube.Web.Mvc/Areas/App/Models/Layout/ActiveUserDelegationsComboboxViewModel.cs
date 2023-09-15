using System.Collections.Generic;
using Google.YouTube.Authorization.Delegation;
using Google.YouTube.Authorization.Users.Delegation.Dto;

namespace Google.YouTube.Web.Areas.App.Models.Layout
{
    public class ActiveUserDelegationsComboboxViewModel
    {
        public IUserDelegationConfiguration UserDelegationConfiguration { get; set; }

        public List<UserDelegationDto> UserDelegations { get; set; }

        public string CssClass { get; set; }
    }
}
