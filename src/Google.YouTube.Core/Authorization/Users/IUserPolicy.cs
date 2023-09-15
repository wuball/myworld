﻿using System.Threading.Tasks;
using Abp.Domain.Policies;

namespace Google.YouTube.Authorization.Users
{
    public interface IUserPolicy : IPolicy
    {
        Task CheckMaxUserCountAsync(int tenantId);
    }
}
