using System.Collections.Generic;
using Google.YouTube.Authorization.Users.Importing.Dto;
using Google.YouTube.Dto;

namespace Google.YouTube.Authorization.Users.Importing
{
    public interface IInvalidUserExporter
    {
        FileDto ExportToFile(List<ImportUserDto> userListDtos);
    }
}
