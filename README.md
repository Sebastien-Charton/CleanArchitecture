# Clean Architecture Solution Template

[![Build](https://github.com/jasontaylordev/CleanArchitecture/actions/workflows/build.yml/badge.svg)](https://github.com/jasontaylordev/CleanArchitecture/actions/workflows/build.yml)
[![CodeQL](https://github.com/jasontaylordev/CleanArchitecture/actions/workflows/codeql.yml/badge.svg)](https://github.com/jasontaylordev/CleanArchitecture/actions/workflows/codeql.yml)
[![Nuget](https://img.shields.io/nuget/v/Clean.Architecture.Solution.Template?label=NuGet)](https://www.nuget.org/packages/Clean.Architecture.Solution.Template)
[![Nuget](https://img.shields.io/nuget/dt/Clean.Architecture.Solution.Template?label=Downloads)](https://www.nuget.org/packages/Clean.Architecture.Solution.Template)

The goal of this template is to provide a straightforward and efficient approach to enterprise application development,
leveraging the power of Clean Architecture and ASP.NET Core. Using this template, you can effortlessly create a WebApi,
while adhering to the principles of Clean Architecture. Getting started is easy - simply install the **.NET template** (
see below for full details).

If you find this project useful, please give it a star. Thanks! ⭐

## Getting Started

The easiest way to get started is to install
the [.NET template](https://www.nuget.org/packages/Clean.Architecture.Solution.Template):

```
dotnet new install Sebastien.Charton.Clean.Architecture.Solution.Template::1.5.0
```

To create a ASP.NET Core Web API-only solution:

```bash
dotnet new ca-sln -o YourProjectName --use-postgresql
```

Launch the app:

```bash
cd src/Web
dotnet run
```

To learn more, run the following command:

```bash
dotnet new ca-sln --help
```

You can create use cases (commands or queries) by navigating to `./src/Application` and running `dotnet new ca-usecase`.
Here are some examples:

To create a new command:

```bash
dotnet new ca-usecase --name CreateTodoList --feature-name TodoLists --usecase-type command --return-type int
```

To create a query:

```bash
dotnet new ca-usecase -n GetTodos -fn TodoLists -ut query -rt TodosVm
```

To learn more, run the following command:

```bash
dotnet new ca-usecase --help
```

## Database

The template is configured to use SQL Server by default. If you would prefer to use SQLite, create your solution using
the following command:

```bash
dotnet new ca-sln --use-sqlite
```

When you run the application the database will be automatically created (if necessary) and the latest migrations will be
applied.

Running database migrations is easy. Ensure you add the following flags to your command (values assume you are executing
from repository root)

* `--project src/Infrastructure` (optional if in this folder)
* `--startup-project src/Web`
* `--output-dir Data/Migrations`

For example, to add a new migration from the root folder:

`dotnet ef migrations add "SampleMigration" --project src\Infrastructure --startup-project src\Web --output-dir Data\Migrations`

## Deploy

The template includes a full CI/CD pipeline. The pipeline is responsible for building, testing, publishing and deploying
the solution to Azure. If you would like to learn more, read
the [deployment instructions](https://github.com/jasontaylordev/CleanArchitecture/wiki/Deployment).

## Technologies

* [ASP.NET Core 8](https://docs.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core)
* [Entity Framework Core 8](https://docs.microsoft.com/en-us/ef/core/)
* [MediatR](https://github.com/jbogard/MediatR)
* [AutoMapper](https://automapper.org/)
* [FluentValidation](https://fluentvalidation.net/)
* [XUnit](https://xunit.net/), [FluentAssertions](https://fluentassertions.com/), [Moq](https://github.com/moq) & [Respawn](https://github.com/jbogard/Respawn)

## Versions

The main branch is now on .NET 8.0. The following previous versions are available:

* [7.0](https://github.com/jasontaylordev/CleanArchitecture/tree/net7.0)
* [6.0](https://github.com/jasontaylordev/CleanArchitecture/tree/net6.0)
* [5.0](https://github.com/jasontaylordev/CleanArchitecture/tree/net5.0)
* [3.1](https://github.com/jasontaylordev/CleanArchitecture/tree/netcore3.1)

## Learn More

* [Clean Architecture with ASP.NET Core 3.0 (GOTO 2019)](https://youtu.be/dK4Yb6-LxAk)
* [Clean Architecture with .NET Core: Getting Started](https://jasontaylor.dev/clean-architecture-getting-started/)

## Support

If you are having problems, please let me know
by [raising a new issue](https://github.com/jasontaylordev/CleanArchitecture/issues/new/choose).

## License

This project is licensed with the [MIT license](LICENSE).
