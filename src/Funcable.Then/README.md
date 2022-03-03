# Funcable.Then

`Funcable.Then` provides a more readable `DSL`. For `IOption<T>` the functions for `Map` and `Bind` become `Then`, and `Match` becomes `Finally`.  The same is true for `IResult<T, TError>` with the added `BiBind` becoming `Then`, and the `BindError` becoming `Catch`.

## Option.Then

`Then` will convert the `T` to a `U` and return an `IOption<U>` if the `IOption<T>` is in a `Some` state.

```csharp
var option = Option.Some<string>("41").Then(s => Convert.ToInt(s) + 1);
option [Some]
(int)option [int]: 42

var option = Option.None<string>.Then(s => Convert.ToInt(s) + 1);
option [None]
```

`Then` will also `apply` the value an `IOption<T>` to the value of `IOption<U>` and return an `IOption<V>` if the `IOption<T>` and the `IOption<U>` are in the `Some` state.

```csharp
var option = Option.Some<string>("41").Then(Option.Some<int>(1), (s, i) => Convert.ToInt(s) + i);
option [Some]
(int)option [int]: 42

var option = Option.None<string>.Then(Option.Some<int>(1), (s, i) => Convert.ToInt(s) + i);
option [None]
```

`Then` also permits function composition.


```csharp
IOption<string> CreateHello() => Option.Some<string>("Hello");
IOption<string> AddWorld(string hello) => Option.Some<string>($"{hello}, World!");

var option = CreateHello().Then(AddWorld));
option [Some]
(string)option [string]: "Hello, World!"
```

## Option.Finally

`Finally` is used to unwrap the internal `T` in a safe manner. If the `IOption<T>` is in a `None` state then that scenario must be explicitly handled.

```csharp
var fullName = Option
  .Some<string>("John")
  .Then(Option.Some<string>("Doe"), (firstName, lastName) => $"{firstName}, {lastName}")
  .Then(name => Option.Some<string>($"{name}, Jr."))
  .Finally(
    name => name,
    "N/A"
  );

fullName [string]: "John Doe, Jr."
```

## Result.Then

`Then` will convert the `T` to a `U` and return a `IResult<U, TError>` if the `IResult<T, TError>` is in an `Ok` state.

```csharp
var result = Result.Ok<string, int>("41").Then(s => Convert.ToInt(s) + 1);
result [Ok]
(int)result [int]: 42

var result = Result.Error<string, int>(-1).Then(s => Convert.ToInt(s) + 1);
result [Error]
(int)result [int]: -1
```

`Then` will also `apply` the value a `IResult<T, TError>` to the value of `IResult<U, TError>` and return a `IResult<V, TError>` if the `IResult<T, TError>` and the `IResult<U, TError>` are in the `Ok` state.

```csharp
var result = Result.Ok<string, int>("41").Then(Result.Ok<int, int>(1), (s, i) => Convert.ToInt(s) + i);
result [Ok]
(int)result [int]: 42

var result = Result.Error<string, int>(-1).Then(Result.Ok<int, int>(1), (s, i) => Convert.ToInt(s) + i);
result [Error]
(int)result [int]: -1
```

`Then` also permits function composition.

```csharp
IResult<string, int> CreateHello() => Result.Ok<string, int>("Hello");
IResult<string, int> AddWorld(string hello) => Result.Ok<string, int>($"{hello}, World!");

var result = CreateHello().Then(AddWorld));
result [Ok]
(string)result [string]: "Hello, World!"
```

## Result.Catch

`Catch` will convert the `TError` to a `UError` and return a `IResult<T, UError>` if the `IResult<T, TError>` is in an `Error` state.

```csharp
var result = Result.Error<string, int>(41).Catch(i => i + 1);
result [Error]
(int)result [int]: 42
```

`Catch` also permits function composition.

```csharp
IResult<string, int> CreateOne() => Result.Error<string, int>(1);
IResult<string, int> AddOne(int num) => Result.Error<string, int>(num + 1);

var result = CreateOne().Catch(AddOne));
result [Error]
(int)result [int]: 2
```

## Result.Finally

`Finally` is used to unwrap the internal `T` or `TError` in a safe manner.

```csharp
var fullName = Result.Ok<string, int>("John")
  .Then(Result.Error<string, int>(-1), (firstName, lastName) => $"{firstName}, {lastName}")
  .Then(name => Result.Ok<string, int>($"{name}, Jr."))
  .Finally(
    name => name,
    error => error.ToString()
  );

fullName [string]: "-1"
```
