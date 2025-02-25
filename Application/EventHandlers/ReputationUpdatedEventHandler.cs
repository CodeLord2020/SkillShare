using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SkillShare.Domain.Events;

namespace SkillShare.Application.EventHandlers
{
    public class ReputationUpdatedEventHandler : INotificationHandler<ReputationUpdatedEvent>
    {
        public Task Handle(ReputationUpdatedEvent notification, CancellationToken cancellationToken)
        {
            var user = notification.User;

            Console.WriteLine($"Reputation updated for user: {user.Email}, new score: {user.ReputationScore}");

            return Task.CompletedTask;
        }
        
    }
}