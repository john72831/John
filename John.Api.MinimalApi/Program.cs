using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<CustomerRepository>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/customers", ([FromServices] CustomerRepository repo) =>
{
    return repo.GetAll();
});

app.MapGet("/customers/{id}", ([FromServices] CustomerRepository repo, Guid id) =>
{
    var customer = repo.GetById(id);

    return customer is not null ? Results.Ok(customer) : Results.NotFound();
});

app.MapPost("/customers", ([FromServices] CustomerRepository repo, Customer customer) =>
{
    repo.Create(customer);

    return Results.Created($"/customers/{customer.Id}", customer);
});

app.MapPost("/customers/{id}", ([FromServices] CustomerRepository repo, Guid id, Customer updatedCustomer) =>
{
    var customer = repo.GetById(id);

    if (customer is null)
    {
        return Results.NotFound();
    }

    repo.Update(updatedCustomer);

    return Results.Ok(updatedCustomer);
});

app.MapPost("/customers/{id}", ([FromServices] CustomerRepository repo, Guid id) =>
{
    repo.Delete(id);

    return Results.Ok();
});

app.Run();

record Customer(Guid Id, string FullName);

class CustomerRepository
{
    private readonly Dictionary<Guid, Customer> _customers = new();

    public void Create(Customer customer)
    {
        if (customer == null)
        {
            return;
        }

        _customers[customer.Id] = customer;
    }

    public Customer GetById(Guid Id)
    {
        return _customers[Id];
    }

    public List<Customer?> GetAll()
    {
        return _customers.Values.ToList();
    }

    public void Update(Customer customer)
    {
        var existingCustomer = GetById(customer.Id);

        if (existingCustomer != null)
        {
            return;
        }

        _customers[customer.Id] = customer;
    }

    public void Delete(Guid Id)
    {
        _customers.Remove(Id);
    }
}