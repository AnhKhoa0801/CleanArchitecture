using MediatR;

namespace Domain.CQRS;

public interface ICommandHandler<in TCommand, TRespondse> : IRequestHandler<TCommand, TRespondse>
    where TCommand : ICommand<TRespondse>
    where TRespondse : notnull
{
}
