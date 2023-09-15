using System.Collections.Generic;
using Google.YouTube.Authorization.Users.Importing.Dto;
using Abp.Dependency;

namespace Google.YouTube.Authorization.Users.Importing
{
    public interface IUserListExcelDataReader: ITransientDependency
    {
        List<ImportUserDto> GetUsersFromExcel(byte[] fileBytes);
    }
}
