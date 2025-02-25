using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SkillShare.Domain.Entities;

namespace SkillShare.Domain.Events
{
    public class TradeCompletedEvent : INotification
    {
        public Trade Trade { get;}
        public TradeCompletedEvent(Trade trade)
        {
            Trade = trade;
        }
        
    }
}