namespace BookExchange.Api.Queries
{
    public interface IQueryDispatcher <out TResult>
    {
        TResult Run();
    }
}