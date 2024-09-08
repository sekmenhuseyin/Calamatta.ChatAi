namespace Calamatta.ChatAi.Domain;

public abstract class Enumeration<TEnum>(int value, string name) : IEquatable<Enumeration<TEnum>>
    where TEnum : Enumeration<TEnum>
{
    private static readonly Dictionary<int, TEnum> Enumerations = GetAllEnumerations();
    private string Name { get; set; } = name;
    private int Value { get; set; } = value;

    public static TEnum? FromValue(int value)
    {
        return Enumerations.GetValueOrDefault(value);
    }

    public static TEnum? FromName(string name)
    {
        return Enumerations.Values.SingleOrDefault(e => e.Name == name);
    }

    public bool Equals(Enumeration<TEnum>? other)
    {
        if (other is null) return false;

        return GetType() == other.GetType() && Value == other.Value;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (obj.GetType() != GetType()) return false;

        return obj is Enumeration<TEnum> other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public override string ToString()
    {
        return Name;
    }

    private static Dictionary<int,TEnum> GetAllEnumerations()
    {
        var type = typeof(TEnum);
        return type
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
            .Where(m => type.IsAssignableFrom(m.FieldType))
            .Select(m => (TEnum)m.GetValue(default)!)
            .ToDictionary(e => e.Value);
    }
}