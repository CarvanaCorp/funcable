# Funcable.Core

`Funcable.Core` contains the base types and functions required to utilize the Functional Programming concepts.

This is the only required assembly. If Functional Programming isn't the desired course, that's ok, the types provided by `Funcable.Core` can still be used in a pure Object Oriented style.

## Option

The `IOption<T>` type is a Functional box type. In the Functional world it is considered a `Functor`, `Applicative`, and `Monad`. Don't get too hung up on those words, they just mean that `IOption<T>` implements `Map`, `Apply (Map)`, and `Bind` functions.

The `IOption<T>` type encapsulates a `T`. It then provides behavior that gives information to the consumer about what's inside. The `IOption<T>` type is meant to express that there is either something inside or nothing inside. This concept is exposed via the `IsSome` and `IsNone` Properties.

The `Option` class provides two construction functions. These are `Option.Some<T>` and `Option.None<T>`.

```csharp
var option = Option.Some<string>("Hello, World!");
option [Some]
(string)option [string]: "Hello, World!"

var option = Option.None<string>();
option [None]
```

The value inside the `IOption<T>` can be a accessed by casting to `T`. Be careful though, as an `InvalidOperationException` will be thrown if the `Option<T>` is in a `None` state.

## Result

The `IResult<T, TError>` type is similar to the `IOption<T>` type. In the Functional world it is also considered a `Functor`, `Applicative`, and `Monad`. In other Functional languages the `IResult<T, TError>` type is called an `Either`.

The `IResult<T, TError>` type encapsulates either a `T` or a `TError`. The `Result<T, TError>` is meant to express that there is one of two types inside (discriminated union). This concept is exposed via the `IsOk` and the `IsError` Properties.

The `Result` class provides two construction functions. These are `Result.Ok<T, TError>` and `Result.Error<T, TError>`.

```csharp
var result = Result.Ok<string, int>("Hello, World!");
result [Ok]
(string)result [string]: "Hello, World!"

var result = Result.Error<string, int>(-1);
result [Error]
(int)result [int]: -1
```

Programmers coming from other Functional languages might struggle slightly with the `IResult<T, TError>` type. This is because in other languages the convention is that the `Left` type is considered the error and the `Right` type the success. `Right is right`.
