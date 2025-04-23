using DevStore.API.Mediator;

namespace DevStore.API.Mediator.Queries;

public class QueryInput<TItem> : MediatorInput<TItem>
    where TItem : QueryResult
{
}