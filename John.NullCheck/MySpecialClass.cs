using System.Globalization;

internal class MySpecialClass
{
    public string Name { get; set; }

    public MySpecialClass(string name)
    {
        Name = name;
    }

    public static bool operator ==(MySpecialClass x, MySpecialClass y) => true;

    public static bool operator !=(MySpecialClass x, MySpecialClass y) => true;

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (ReferenceEquals(obj, null))
        {
            return false;
        }

        throw new NotImplementedException();
    }

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }
}