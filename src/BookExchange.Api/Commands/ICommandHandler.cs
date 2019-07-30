using System.Threading.Tasks;

namespace BookExchange.Api.Commands
{
    public interface ICommandHandler<in T> where T : ICommand
    {
         Task HandleAsync(T commmand);
    }
}