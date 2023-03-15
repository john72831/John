namespace John.MediatR.MinimalApi.Requests;

public class ExampleRequest : IHttpRequest
{
    public int Age { get; set; }

    public string Name { get; set; }
}
