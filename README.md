# Welcome to Funcable

`Funcable` is a `C#` library that borrows Functional Programming concepts and attempts to apply them to
C#'s Object Oriented Imperative world.

`Funcable` is heavily inspired by C#'s sister language, `F#`.

## Funcable.Core

`Funcable.Core` contains the base types and functions required to utilize the Functional Programming concepts.

This assembly is the only one really required. If Functional Programming isn't the desired course, that's ok, the types here can still be used in a pure Object Oriented style.

### Option

The `IOption<T>` type is a Functional box type. In the Functional world it is considered a `Functor`, `Applicative`, and `Monad`. Don't get too hung up on those words, they just mean that `IOption<T>` implements `Map`, `Apply (Map)`, and `Bind` functions.

The `IOption<T>` type encapsulates a `T`. It then provides behavior that gives information to the consumer about what's inside. The `IOption<T>` type is meant to express that there is either something inside or nothing inside. This concept is exposed via the `IsSome` and `IsNone` Properties.

The `Option` class provides two construction methods. These are `Option.Some<T>` and `Option.None<T>`.

```csharp
var some = Option.Some<string>("Hello, World!");
some.IsSome [bool]: true
some.IsNone [bool]: false
(string)some [string]: "Hello, World!"

var none = Option.None<string>();
none.IsSome [bool]: false
none.IsNone [bool]: true
```

The value inside the `IOption<T>` can be a accessed by casting to `T`. Be careful though, as an `InvalidOperationException` will be thrown if the `Option<T>` is in a `None` state.

## Result

The `IResult<T, TError>` type is similar to the `IOption<T>` type. In the Functional world it is also considered a `Functor`, `Applicative`, and `Monad`. In other Functional languages the `IResult<T, TError>` type is called an `Either`.

The `IResult<T, TError>` type encapsulates either a `T` or a `TError`. The `Result<T, TError>` is meant to express that there is one of two types inside (discriminated union). This concept is exposed via the `IsOk` and the `IsError` Properties.

The `Result` class provides two construction methods. These are `Result.Ok<T, TError>` and `Result.Error<T, TError>`.

```csharp
var ok = Result.Ok<string, int>("Hello, World!");
ok.IsOk [bool]: true
ok.IsError [bool]: false
(string)ok [string]: "Hello, World!"

var error = Result.Error<string, int>(-1);
error.IsOk [bool]: false
error.IsError [bool]: true
(int)error [int]: -1
```

Programmers coming from other Functional languages might struggle slightly with the `Result<T, TError>` type. This is because in other languages the convention is that the `Left` type is considered the error and the `Right` type the success. `Right is right`.

## Funcable.Control

`Funcable.Control` is where the real magic lies. This library provides the `Map`, `Bind,` and `Match` methods to `IOption<T>` and `IResult<T, TError>` that allow the Functional composition style to be used.

### Option.Map

`Map` will convert the `T` to a `U` and return an `IOption<U>` if the `IOption<T>` is in a `Some` state.

```csharp
var some = Option.Some<string>("41").Map(s => Convert.ToInt(s) + 1);
some.IsSome [bool]: true
some.IsNone [bool]: false
(int)some [int]: 42

var none = Option.None<string>.Map(s => Convert.ToInt(s) + 1);
none.IsSome [bool]: false
none.IsNone [bool]: true
```

`Map` will also `apply` the value an `IOption<T>` to the value of `IOption<U>` and return an `IOption<V>` if the `IOption<T>` and the `IOption<U>` are in the `Some` state.

```csharp
var some = Option.Some<string>("41").Map(Option.Some<int>(1), (s, i) => Convert.ToInt(s) + i);
some.IsSome [bool]: true
some.IsNone [bool]: false
(int)some [int]: 42

var none = Option.None<string>.Map(Option.Some<int>(1), (s, i) => Convert.ToInt(s) + i);
none.IsSome [bool]: false
none.IsNone [bool]: true
```

### Option.Bind

`Bind` permits function composition.

```csharp
IOption<string> CreateHello() => Option.Some<string>("Hello");
IOption<string> AddWorld(string hello) => Option.Some<string>($"{hello}, World!");

var some = CreateHello().Bind(AddWorld));
some.IsSome [bool]: true
some.IsNone [bool]: false
(string)some [string]: "Hello, World!"
```

### Option.Match

`Match` is used to unwrap the internal `T` in a safe manner. If the `IOption<T>` is in a `None` state then that scenario must be explicitly handled.

```csharp
var fullName = Option
  .Some<string>("John")
  .Map(Option.Some<string>("Doe"), (firstName, lastName) => $"{firstName}, {lastName}")
  .Bind(name => Option.Some<string>($"{name}, Jr."))
  .Match(
    name => name,
    "N/A"
  );

fullName [string]: "John Doe, Jr."
```

### Result.Map

`Map` will convert the `T` to a `U` and return a `IResult<U, TError>` if the `IResult<T, TError>` is in an `Ok` state.

```csharp
var ok = Result.Ok<string, int>("41").Map(s => Convert.ToInt(s) + 1);
ok.IsOk [bool]: true
ok.IsError [bool]: false
(int)ok [int]: 42

var error = Result.Error<string, int>(-1).Map(s => Convert.ToInt(s) + 1);
error.IsOk [bool]: false
error.IsError [bool]: true
(int)error [int]: -1
```

`Map` will also `apply` the value a `IResult<T, TError>` to the value of `IResult<U, TError>` and return a `IResult<V, TError>` if the `IResult<T, TError>` and the `IResult<U, TError>` are in the `Ok` state.

```csharp
var ok = Result.Ok<string, int>("41").Map(Result.Ok<int, int>(1), (s, i) => Convert.ToInt(s) + i);
ok.IsOk [bool]: true
ok.IsError [bool]: false
(int)ok [int]: 42

var error = Result.Error<string, int>(-1).Map(Result.Ok<int, int>(1), (s, i) => Convert.ToInt(s) + i);
error.IsOk [bool]: false
error.IsError [bool]: true
(int)error [int]: -1
```

### Result.Bind

`Bind` permits function composition.

```csharp
IResult<string, int> CreateHello() => Result.Ok<string, int>("Hello");
IResult<string, int> AddWorld(string hello) => Result.Ok<string, int>($"{hello}, World!");

var ok = CreateHello().Bind(AddWorld));
ok.IsOk [bool]: true
ok.IsError [bool]: false
(string)ok [string]: "Hello, World!"
```

### Result.Match

`Match` is used to unwrap the internal `T` or `TError` in a safe manner.

```csharp
var fullName = Result.Ok<string, int>("John")
  .Map(Result.Error<string, int>(-1), (firstName, lastName) => $"{firstName}, {lastName}")
  .Bind(name => Result.Ok<string, int>($"{name}, Jr."))
  .Match(
    name => name,
    error => error.ToString()
  );

fullName [string]: "-1"
```

## More

There are methods that expose behavior as well for both the `IOption<T>` type and the `IResult<T, TError>`. Take a look at the source to get further acquanted with them.
