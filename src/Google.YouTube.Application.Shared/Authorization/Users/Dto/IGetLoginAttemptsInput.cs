using Abp.Application.Services.Dto;

namespace Google.YouTube.Authorization.Users.Dto
{
    public interface IGetLoginAttemptsInput: ISortedResultRequest
    {
        string Filter { get; set; }
    }
}