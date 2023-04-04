using MediatR;

namespace Domain.CQRS;

public interface IQueryHandler<in TQuery, TRespondse> : IRequestHandler<TQuery, TRespondse>
    where TQuery : IQuery<TRespondse>
    where TRespondse : notnull
{
}
