# Ukko

*Ukko* the Finnish god of weather, and the skies. The highest of the pagan gods resembling Thor with an axe that allows him to control lightning.

## Tech Stack

* [Ionic](https://ionicframework.com/)
    * [Capacitor](https://capacitor.ionicframework.com/)
* [ASP.NET Core WebAPI 2.2](https://github.com/aspnet/Home)
    * [Refit REST Library](https://github.com/reactiveui/refit)
    * [Swagger](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)
    * [Json.NET](https://www.newtonsoft.com/json)
* [VS Code](https://code.visualstudio.com/download)
    * [TSLint](https://marketplace.visualstudio.com/items?itemName=ms-vscode.vscode-typescript-tslint-plugin)
    * [OmniSharp](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp)

## Services

* [OpenWeatherMapAPI](https://openweathermap.org/api)

## Getting Started

1. Install Ionic
2. Install [.NET Core 2.2 SDK](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.103-windows-x64-installer)
3. Install some code editor of your choice. VS Code is recommended.

### Usage

#### Running the API Project Locally
Navigate to `...\<CLONED_REPO_LOCATION>\Ukko\Ukko.API\` and run the following commands:

```bash
$env:ASPNETCORE_ENVIRONMENT="Development";
dotnet run
```

> The first command sets the application in developer mode for your local. The second runs the application.

After running this once you can just use `dotnet run` to run the application in development mode. You will need to manually change this if you want to change environments.

#### Running Ionic Project Locally
Navigate to `...\<CLONED_REPO_LOCATION>\Ukko\Ukko.Ionic\` and run the following command:

```bash
ionic serve
```
> If you want to run in a device emulator follow these [instructions](https://cordova.apache.org/docs/en/8.x/guide/platforms/android/).

## API Documentation

There is a swagger doc located within the project located at:

**Developer**

```url
<LOCAL_IP>:<PORT>/swagger
```

## Contribution Conventions and Guidelines

To keep the developers happy please use conventions and guidelines throughout the application. Developers can sometimes be very grumpy creatures.

* [Microsoft C# Coding Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions)
* [Microsoft REST API Guidelines](https://github.com/Microsoft/api-guidelines/blob/vNext/CONTRIBUTING.md)
* [Github Flow](https://guides.github.com/introduction/flow/)
* [White House Web API Standards](https://github.com/WhiteHouse/api-standards/blob/master/README.md)

To start contributing fork the project, and work from the beta branch. Then submit a pull request. Pleas eonly work on current issues, and include a *#ISSUE_NUMBER* in the commit message.
