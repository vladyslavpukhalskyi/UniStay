using Domain.Users;
using Optional;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Queries
{
    public interface IUsersQueries
    {
        Task<Option<User>> GetById(UserId id, CancellationToken cancellationToken);

        Task<Option<User>> GetByEmail(string email, CancellationToken cancellationToken);

        Task<IReadOnlyList<User>> GetAll(CancellationToken cancellationToken);
    }
}