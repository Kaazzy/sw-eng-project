namespace sw_project.Tests.TestHelpers;

internal static class AnonymousProjectionReader
{
    public static T GetProperty<T>(object obj, string propertyName)
    {
        var prop = obj.GetType().GetProperty(propertyName);
        if (prop is null)
            throw new InvalidOperationException($"Property '{propertyName}' not found on type '{obj.GetType().FullName}'.");

        var value = prop.GetValue(obj);
        if (value is null)
            return default!;

        return (T)value;
    }
}
