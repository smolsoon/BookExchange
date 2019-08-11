using System;

namespace BookExchange.Core.Model
{
    public class Lent
    {
        public Guid UserId { get; set; }
        public Guid SubscriberId { get; set; }
        public bool Approved { get; set; }
        public bool LentOn(Guid userId, Guid subscriberId)
        {
            return true;
        }
    }
}