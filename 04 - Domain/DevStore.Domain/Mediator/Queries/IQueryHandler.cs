using DevStore.API.Mediator;

namespace DevStore.API.Mediator.Queries;

public interface IQueryHandler<in TQueryInput, TItem> : IMediatorHandler<TQueryInput, TItem>
    where TQueryInput : QueryInput<TItem>
    where TItem : QueryResult, new()
{
}