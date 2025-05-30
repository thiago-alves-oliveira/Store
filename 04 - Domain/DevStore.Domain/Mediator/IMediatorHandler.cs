﻿using MediatR;

namespace DevStore.API.Mediator;

public interface IMediatorHandler<in TMediatorInput, TMediatorResult>
    : IRequestHandler<TMediatorInput, TMediatorResult>
    where TMediatorInput : IMediatorInput<TMediatorResult>
    where TMediatorResult : IMediatorResult, new()
{
}