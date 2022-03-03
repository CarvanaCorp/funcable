# Funcable.Control

`Funcable.Control` is where the magic happens. This library provides the `Map`, `Bind,` and `Match` functions to `IOption<T>` and `IResult<T, TError>` that allow the Functional composition style to be used.

## Option.Map

`Map` will convert the `T` to a `U` and return an `IOption<U>` if the `IOption<T>` is in a `Some` state.

```csharp
var option = Option.Some<string>("41").Map(s => Convert.ToInt(s) + 1);
option [Some]
(int)option [int]: 42

var option = Option.None<string>.Map(s => Convert.ToInt(s) + 1);
option [None]
```

`Map` will also `apply` the value an `IOption<T>` to the value of `IOption<U>` and return an `IOption<V>` if the `IOption<T>` and the `IOption<U>` are in the `Some` state.

```csharp
var option = Option.Some<string>("41").Map(Option.Some<int>(1), (s, i) => Convert.ToInt(s) + i);
option [Some]
(int)option [int]: 42

var option = Option.None<string>.Map(Option.Some<int>(1), (s, i) => Convert.ToInt(s) + i);
option [None]
```

## Option.Bind

`Bind` permits function composition.

```csharp
IOption<string> CreateHello() => Option.Some<string>("Hello");
IOption<string> AddWorld(string hello) => Option.Some<string>($"{hello}, World!");

var option = CreateHello().Bind(AddWorld));
option [Some]
(string)option [string]: "Hello, World!"
```

## Option.Match

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

## Result.Map

`Map` will convert the `T` to a `U` and return a `IResult<U, TError>` if the `IResult<T, TError>` is in an `Ok` state.

```csharp
var result = Result.Ok<string, int>("41").Map(s => Convert.ToInt(s) + 1);
result [Ok]
(int)result [int]: 42

var result = Result.Error<string, int>(-1).Map(s => Convert.ToInt(s) + 1);
result [Error]
(int)result [int]: -1
```

`Map` will also `apply` the value a `IResult<T, TError>` to the value of `IResult<U, TError>` and return a `IResult<V, TError>` if the `IResult<T, TError>` and the `IResult<U, TError>` are in the `Ok` state.

```csharp
var result = Result.Ok<string, int>("41").Map(Result.Ok<int, int>(1), (s, i) => Convert.ToInt(s) + i);
result [Ok]
(int)result [int]: 42

var result = Result.Error<string, int>(-1).Map(Result.Ok<int, int>(1), (s, i) => Convert.ToInt(s) + i);
result [Error]
(int)result [int]: -1
```

## Result.Bind

`Bind` permits function composition.

```csharp
IResult<string, int> CreateHello() => Result.Ok<string, int>("Hello");
IResult<string, int> AddWorld(string hello) => Result.Ok<string, int>($"{hello}, World!");

var result = CreateHello().Bind(AddWorld));
result [Ok]
(string)result [string]: "Hello, World!"
```

## Result.Match

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
