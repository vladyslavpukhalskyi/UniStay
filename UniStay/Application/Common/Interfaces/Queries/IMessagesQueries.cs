using Domain.Messages;
using Domain.Users;
using Optional;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Queries
{
    public interface IMessagesQueries
    {
        Task<IReadOnlyList<Message>> GetAllMessagesForUser(UserId userId, CancellationToken cancellationToken);

        Task<IReadOnlyList<Message>> GetConversation(UserId senderId, UserId receiverId, CancellationToken cancellationToken);

        Task<Option<Message>> GetById(MessageId id, CancellationToken cancellationToken);
    }
}