# Funcable &middot; [![Build status](https://carvanadev.visualstudio.com/Carvana.OpenSource/_apis/build/status/Funcable)](https://carvanadev.visualstudio.com/Carvana.OpenSource/_build/latest?definitionId=20287) [![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg)](https://help.github.com/articles/creating-a-pull-request/) [![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](./LICENSE)

`Funcable` is a `C#` library that borrows Functional Programming concepts and attempts to apply them to
C#'s Object Oriented Imperative world.

`Funcable` is heavily inspired by C#'s sister language, `F#`.

## Packages

| Package | Version | Comment |
| --- | --- | --- |
| [Funcable.Core](https://www.nuget.org/packages/Funcable.Core/) | [![NuGet](https://img.shields.io/nuget/v/Funcable.Core.svg)](https://www.nuget.org/packages/Funcable.Core/) | Core Types ([docs](./src/Funcable.Core/README.md)) |
| [Funcable.Control](https://www.nuget.org/packages/Funcable.Control/) | [![NuGet](https://img.shields.io/nuget/v/Funcable.Control.svg)](https://www.nuget.org/packages/Funcable.Control/) | Optional Control System ([docs](./src/Funcable.Control/README.md)) |
| [Funcable.Then](https://www.nuget.org/packages/Funcable.Then/) | [![NuGet](https://img.shields.io/nuget/v/Funcable.Then.svg)](https://www.nuget.org/packages/Funcable.Then/) | Optional DSL ([docs](./src/Funcable.Then/README.md)) |

## Design

`Funcable` has been designed to promote extensibility.

The `Core` types intentionally lack behavior. This allows anyone to build out a system of control for the `Core` types .

The `Control` library is not required, but provides a system of control for those that do not desire to build their own. The `Control` library is responsible for making code flow decisions based on the concretions of the `IOption<T>` and `IResult<T, TError>` interfaces.

The `Then` library is not required, but provides a different `DSL` by aliasing the functions from the `Control` library.

## Funcable.Core

`Funcable.Core` contains the base types and functions required to utilize the Functional Programming concepts.

This is the only required assembly. If Functional Programming isn't the desired course, that's ok, the types provided by `Funcable.Core` can still be used in a pure Object Oriented style.

## Funcable.Control

`Funcable.Control` is where the magic happens. This library provides the `Map`, `Bind,` and `Match` functions to `IOption<T>` and `IResult<T, TError>` that allow the Functional composition style to be used.

## Funcable.Then

`Funcable.Then` provides a more readable `DSL`. For `IOption<T>` the functions for `Map` and `Bind` become `Then`, and `Match` becomes `Finally`.  The same is true for `IResult<T, TError>` with the added `BiBind` becoming `Then`, and the `BindError` becoming `Catch`.

### License

Distributed under the MIT License. See [LICENSE](./LICENSE) for more information.
