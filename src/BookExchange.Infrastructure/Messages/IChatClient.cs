using System;
using System.Threading.Tasks;

namespace BookExchange.Infrastructure.Messages
{
    public interface IChatClient
    {
         Task ReceiveMessage(int id, int? baseId, double? frequency, byte? modulation, byte? agc1, byte? agc2, DateTime timeStamp);
    }
}