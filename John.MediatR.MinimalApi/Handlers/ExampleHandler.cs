using John.MediatR.MinimalApi.Requests;
using MediatR;
using Microsoft.AspNetCore.Http.Features;

namespace John.MediatR.MinimalApi.Handlers;

public class ExampleHandler : IRequestHandler<ExampleRequest, IResult>
{
    public ExampleHandler()
    {

    }

    public async Task<IResult> Handle(ExampleRequest request, CancellationToken cancellationToken)
    {
        await Task.Delay(10, cancellationToken);
        return Results.Ok(new
        {
            message = $"The age was: {request.Age} and the name was: {request.Name}"
        });
    }
}
