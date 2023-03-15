using MediatR;

namespace John.MediatR.MinimalApi.Requests;

public interface IHttpRequest : IRequest<IResult>
{
}
