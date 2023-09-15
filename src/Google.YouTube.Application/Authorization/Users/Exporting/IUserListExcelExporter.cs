using System.Collections.Generic;
using Google.YouTube.Authorization.Users.Dto;
using Google.YouTube.Dto;

namespace Google.YouTube.Authorization.Users.Exporting
{
    public interface IUserListExcelExporter
    {
        FileDto ExportToFile(List<UserListDto> userListDtos);
    }
}