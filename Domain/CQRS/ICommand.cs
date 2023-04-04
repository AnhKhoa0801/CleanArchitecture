using MediatR;

namespace Domain.CQRS;

public interface ICommand<out T> : IRequest<T> where T : notnull
{
}
