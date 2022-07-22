# React.NetCore6SwaggerOdataEntityFramework
[Dev Essentials](https://my.visualstudio.com/Benefits)

[boxstarter](https://gist.github.com/joshmccall221/26393292659b8db8a6de19739fca1b27)

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
Install-Package Swashbuckle.AspNetCore -Version 6.2.3
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
[EnableQuery]
public IEnumerable<WeatherForecast> Get()
```

