# Options in Domain Models

The Option type lends itself well to domain modeling. It expresses the intent of a particular piece of data and how the business sees it.

For example, the business may have need of a `Customer` model. The requirement for that model could be that a `FirstName` is required and a `LastName` is required, but the business may want to track a `MiddleName` should one exist. This is how that model would look using the `Funcable.IOption<T>`

```csharp
public sealed record Customer
{
    public string FirstName { get; init; }

    public IOption<string> MiddleName { get; init; }

    public string LastName { get; init; }
}
```

In the above example it's quite clear that the `MiddleName` property is optional.

*Note:* In `C# 8` Microsoft added `Nullable` reference types. This serves a simlar purpose. If it's preferred to use that syntax then please do so.

Here's an example of how you might build up this Domain model when a new `Customer` needs to be created.
```csharp
public IOption<string> AddMiddleName(string? middleName = "") => middleName switch
{
    var mn when string.IsNullOrWhitespace(mn) => None<string>(),
    _ => Some(middleName)
};

public Customer CreateCustomer(string firstName, string lastName, string? middleName = "") => new()
{
    FirstName = firstName,
    MiddleName = AddMiddleName(middleName),
    LastName = lastName
};
```
