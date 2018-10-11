# Ukko

*Ukko* the Finnish god of weather, and the skies. The highest of the pagan gods resembling Thor with an axe that allows him to control lightning.

## Tech Stack

* [Xamarin.Forms](https://github.com/xamarin/Xamarin.Forms)
* [ReactiveUI](https://github.com/reactiveui/ReactiveUI)
* [Refit REST Library](https://github.com/reactiveui/refit)
* [Splat](https://github.com/reactiveui/splat)
* [ASP.NET Core WebAPI 2.1](https://github.com/aspnet/Home)

## Services

* [OpenWeatherMapAPI](https://openweathermap.org/api)

## Getting Started

### Install

* Download and install [.NET Core 2.1 SDK](https://www.microsoft.com/net/download)
* Install Visual Studio Community with .NET Core, and Xamarin options selected. Will be targeting the three latest versions and all of their updates for Android, and iOS. *Visual Studio only please to keep this consistent as other IDEs have cause build errors for one or the other with metadata conflicts, and file generation.*
* Install [Conveyor](https://marketplace.visualstudio.com/items?itemName=vs-publisher-1448185.ConveyorbyKeyoti) and follow all of the directions on the page for configuration. This will greatly simplify testing on a remote device. If you have some other preferred method go ahead and do that. *Might only work on Windows*.
* Clone the repo

**Please be sure to build locally and that the build is successful, and tests have passed before pushing to GitHub. Regression tests included.** Breaking the build may result in expulsion as a collaborator.

#### Ukko API

There are two ways to run this application one is within Visual Studio, and the other is through command line which will later be detailed in the usage section. You are free to use whichever you want to run the application. During setup to get our machine ip setup correctly its easiest to at least run it initially through Visual Studio.

Open the *Ukko.API* solution in visual studio *(.sln filetype)*, and run the debugger. A small window should pop up for conveyor if installed containing at least one row. Copy the Remote URL and port then open postman to test that it was the correct address if more than one was present. In postman create a GET request and paste in the following `<REMOTE_URL>/api/Weather/Current/<ZIPCODE>` and send. You should get back a current weather response.

#### Ukko Applications

Run Ukko.API and run it then open *Ukko.sln* in Visual Studio. Locate and open *ApplicationSettings.cs* file located in the root of the *Ukko* project in Solution Explorer. Then paste the Remote URL you got in the section above and paste in ApplicationSettings file for the *LOCALHOST_API_ADDRESS* value; appending `/api` at the end. Should look like the following:

```csharp
public static readonly string LOCALHOST_API_ADDRESS = "http://192.168.86.24:45455/api";
```

This is so you can test the API locally within the android emulator. This will be most useful after changes are made to the API project, and to offload costs with server bandwith.

### Usage

The project is comprised of two parts. One is the API / backend, and the other is the Xamarin project which accounts for users and frontend across mobile/Windows apps. While developing the API project must be ran seperatly from the xamarin project to hit the APIs at least until a mock API is created.

#### Ukko API

There are two ways to run the application, but debugging is easier in Visual Studio.

##### Visual Studio

Open the Ukko.API solution, and hit F5 or go to the Debug menu and select Start Debugging.

##### Command Line

Enter the following command in the `...\<CLONED_REPO_LOCATION>\Ukko\Ukko.API\` folder.

```bash
dotnet run
```

#### Ukko Applications

The application projects must run Ukko API to test since they use the API project to perform API calls. The command line approach for the Ukko API is recommended here since it is lightweight.

Open the Ukko project in Visual Studio and run the Ukko.Android project.

>*You may have to explicitly start the Android/iOS/UWP application if the startup project is not set to the desired Ukko.PLATFORM project already.*

## API Documentation

There is a swagger doc located within the project located at:

**Developer**

```url
<LOCAL_IP>:<PORT>/swagger
```

**Production**

```url
https://ukkoapi.azurewebsites.net/swagger
```

## UI/UX and Design Tools

For the most part the design should follow the native platform design guidelines. This is to keep it as familiar and easy to use as possible in each respective ecosystem for their users. All design in Xamarin should be handled in XAML and not the codebehind.

* To begin with Android will be the only project we will focus on. Eventually we shall add in functionality for iOS and UWP as desired to keep the initial release small.
* [iOS](https://developer.apple.com/design/human-interface-guidelines/ios/overview/themes/)
* [Android](https://material.io/design/)
* [UWP](https://developer.microsoft.com/en-us/windows/apps/design)

For the design portion a couple tools will be used to help the design process go a little more smoothly across different screen sizes, aspect ratios, etc and so we can keep a common theme. 

* [Adobe XD](https://www.adobe.com/products/xd.html)
* [Zeplin](https://zeplin.io/)

Design files and assets should be moved to their respective location. So in the case of Adobe XD files they should be saved to the iOS folder for iOS designs on the design branch. The assets exported for direct use should be in the correct location within the project for development on a development branch.

## Contribution Conventions and Guidelines

To keep the developers happy please use conventions and guidelines throughout the application. Developers can sometimes be very grumpy creatures.

* [Microsoft C# Coding Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions)
* [Microsoft REST API Guidelines](https://github.com/Microsoft/api-guidelines/blob/vNext/CONTRIBUTING.md)
* [Github Flow](https://guides.github.com/introduction/flow/)
* [White House Web API Standards](https://github.com/WhiteHouse/api-standards/blob/master/README.md)

To start contributing fork the project, and work from the beta branch. Then submit a pull request. Pleas eonly work on current issues, and include a *#ISSUE_NUMBER* in the commit message.
