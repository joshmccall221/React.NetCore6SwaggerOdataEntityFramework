# React.NetCore6SwaggerOdataEntityFramework
[Dev Essentials](https://my.visualstudio.com/Benefits)

[Azure Portal](https://portal.azure.com/#home)

[boxstarter](https://gist.github.com/joshmccall221/26393292659b8db8a6de19739fca1b27)


``` create.ps1
$project = 'UI'
$testproject = 'Test' + $project

$project
$testproject


dotnet new webapi --output $project
dotnet new xunit --output $testproject

dotnet new sln --name BlazorUI
dotnet sln add $project
dotnet sln add $testproject

dotnet add $project package Swashbuckle.AspNetCore
dotnet add $project package Microsoft.AspNetCore.OData 

dotnet add $testproject package bunit 
dotnet add $testproject package comparenetobjects 
dotnet add $testproject package deepcloner 
dotnet add $testproject package fluentassertions 
dotnet add $testproject package moq 
dotnet add $testproject package tynamix.objectfiller
start .

```

```
Set-ExecutionPolicy RemoteSigned
. { iwr -useb http://boxstarter.org/bootstrapper.ps1 } | iex; get-boxstarter -Force
cinst nvm -y
nvm install lts
nvm use lts
cinst postman
```

[Get started with Swashbuckle and ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-6.0&tabs=visual-studio)

```
Install-Package Swashbuckle.AspNetCore 
builder.Services.AddSwaggerGen();
app.UseSwagger();
app.UseSwaggerUI();
```

[Entity Framework](https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-6.0)

```
public class WeatherForecast
{
    public Guid Id { get; set; }


add-migration init
update-database
```

[Up & Running w/ OData in ASP.NET 6](https://devblogs.microsoft.com/odata/up-running-w-odata-in-asp-net-6/)

```
Install-Package Microsoft.AspNetCore.OData 

builder.Services.AddControllers().AddOData(opt => opt.EnableQueryFeatures().AddRouteComponents("odata", GetEdmModel()));

IEdmModel GetEdmModel()
{
    var builder = new ODataConventionModelBuilder();
    builder.EntitySet<WeatherForecast>("WeatherForecasts");
    return builder.GetEdmModel();
}

[EnableQuery]
public IEnumerable<WeatherForecast> Get()
```



