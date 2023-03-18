using OneOf;
using OneOf.Types;

namespace John.OneOfExample;

[GenerateOneOf]
public partial class MovieResult : OneOfBase<Movie, NotFound>
{
}
