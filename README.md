# Ukko

*Ukko* the Finnish god of weather, and the skies. The highest of the pagan gods resembling Thor with an axe that allows him to control lightning.

## Tech Stack

* [Ionic](https://ionicframework.com/)
    * [Capacitor](https://capacitor.ionicframework.com/)
    * [Ionic Sketch](https://ionicsketch.com/) *Download demo*
* [ASP.NET Core WebAPI 2.2](https://github.com/aspnet/Home)
    * [Refit REST Library](https://github.com/reactiveui/refit)
    * [Swagger](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)
    * [Json.NET](https://www.newtonsoft.com/json)
* [VS Code](https://code.visualstudio.com/download)
    * [TSLint](https://marketplace.visualstudio.com/items?itemName=ms-vscode.vscode-typescript-tslint-plugin)
    * [OmniSharp](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp)
* [Lunacy](https://www.microsoft.com/en-us/p/lunacy-sketch-for-windows/9pnlmkkpcljj?ocid=badge&rtc=1&activetab=pivot:overviewtab)

## Services

* [OpenWeatherMapAPI](https://openweathermap.org/api)

## Getting Started

1. Install Ionic
2. Install [.NET Core 2.2 SDK](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.103-windows-x64-installer)
3. Install Lunacy
4. Install some code editor of your choice. VS Code is recommended.

### Usage

The project is comprised of two parts. One is the API / backend, and the other is the Xamarin project which accounts for users and frontend across mobile/Windows apps. While developing the API project must be ran seperatly from the xamarin project to hit the APIs at least until a mock API is created.

### Command Line

Enter the following command in the `...\<CLONED_REPO_LOCATION>\Ukko\Ukko.API\` folder.

```bash
dotnet run
```

## API Documentation

There is a swagger doc located within the project located at:

**Developer**

```url
<LOCAL_IP>:<PORT>/swagger
```

## UI/UX and Design Tools

Lunacy (sketch for windows) will be used to create designs.

## Contribution Conventions and Guidelines

To keep the developers happy please use conventions and guidelines throughout the application. Developers can sometimes be very grumpy creatures.

* [Microsoft C# Coding Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions)
* [Microsoft REST API Guidelines](https://github.com/Microsoft/api-guidelines/blob/vNext/CONTRIBUTING.md)
* [Github Flow](https://guides.github.com/introduction/flow/)
* [White House Web API Standards](https://github.com/WhiteHouse/api-standards/blob/master/README.md)

To start contributing fork the project, and work from the beta branch. Then submit a pull request. Pleas eonly work on current issues, and include a *#ISSUE_NUMBER* in the commit message.
