# Dotnet CLI

## Creating a New Solution

Create a folder for the solution first. Go into that solution, then:

```shell
dotnet new sln
```

> [!tip] You can Add a name for the solution otherwise it just uses the name of the folder
> `dotnet new sln --name CustomersSolution`


## Creating a Project

```shell
dotnet new webapi --output CustomersApi --no-https
```

Create a Minimal API

```
dotnet new webapi -minimal -o TodoApi --no-https
```

## Adding the Project to the Solution

```shell
dotnet sln add .\CustomersApi\CustomersApi.csproj          
```

## Adding Packages

```shell
dotnet add package mongodb.driver
```

## Adding References

```shell
dotnet add reference ..\..\SharedModels\SharedModels.csproj
```

## Watching (Tests)

```shell
dotnet watch test
```
