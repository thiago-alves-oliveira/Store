using MediatR;

namespace DevStore.API.Mediator;

public interface IMediatorInput<out TMediatorResult>
    : IRequest<TMediatorResult> where TMediatorResult : IMediatorResult
{

}