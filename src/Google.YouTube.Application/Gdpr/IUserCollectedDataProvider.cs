using System.Collections.Generic;
using System.Threading.Tasks;
using Abp;
using Google.YouTube.Dto;

namespace Google.YouTube.Gdpr
{
    public interface IUserCollectedDataProvider
    {
        Task<List<FileDto>> GetFiles(UserIdentifier user);
    }
}
