
using John.OneOfExample;
using OneOf.Types;

public class Program
{
    private static void Main(string[] args)
    {
        var repository = new Repository();
        var result = repository.Update(new Movie());

        result.Match((movie) => 1, _ => 2);
        result.Switch((movie) => Console.WriteLine("1"), _ => Console.WriteLine("2"));
    }
}

public class Repository
{
    public MovieResult Update(Movie moive)
    {
        if (moive is null)
            return new NotFound();
        else
            return moive;
    }
}

public class Movie
{
    public string Name { get; set; } = "";
}

