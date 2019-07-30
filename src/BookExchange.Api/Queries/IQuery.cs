namespace BookExchange.Api.Queries
{
    public interface IQuery<out TResult>
    {
         TResult Execute();
    }
}