# Newsfeed App (temporary name)
Client application for a social network newsfeed service, built with ASP.NET Core 2.0 and Angular 5. Currently unfinished.

## Built With
* [ASP.NET Core 2.0](https://github.com/aspnet/Home) - Server-side framework
* [NuGet](https://www.nuget.org/) - Dependency Management
* [ASP.NET Core 2.0 + Angular 5 VS Project Template RC](https://docs.microsoft.com/en-us/aspnet/core/spa/angular?tabs=visual-studio) - VS Template release candidate, featuring pre-established client-server communication and a list of packaged pre-installed
* [Angular 5.2.0](https://angular.io/) - Client-side framework
* [npm 5.6.0](https://angular.io/) - Client-side package management
* [webpack 3.10.0](https://webpack.js.org/) - Client-side bundling and minification
* [Angular Material 5.2.0](https://material.angular.io/) - Material Design components library

## Software used in development
* [Visual Studio 2017 Community 15.5.6](https://www.visualstudio.com/ru/downloads/) - Main IDE of choice
* [Visual Studio Code 1.21.0-insiders](https://code.visualstudio.com/) - Lightweight IDE mostly used for editing UI and making quick changes.
* [Angular CLI 1.6.3](https://cli.angular.io/) - Command Line Interface for updating, installing and serving aid
* [Postman 5.3.2](https://www.getpostman.com/) - API debugging and testing tool

## Development backlog
:heavy_check_mark: - feature is (mostly) finished.

:negative_squared_cross_mark: - feature is semi-finished, contains bugs or fakes some interactions.

:x: - feature is mostly or completely undone.

### Accounts
* Client-side: 
  *  :heavy_check_mark: **Registration**: done; data is validated, services are set up.
  *  :heavy_check_mark: **Authorization**: done; server responses are displayed in a snackbar.
  *  :heavy_check_mark: **Routing**: done; all routes are protected by AuthGuard and AnonymousGuard services, unaccessible depending on local storage contents.
  
* Server-side: 
  *   :x: **Registration**: echoes username without saving the data.
  *   :negative_squared_cross_mark: **Authorization**: input data is compared with the fake-database model data; server returns error message in case of authorization error; upon successful authorization, only the account ID is returned (instead of JWT token).
  *   :negative_squared_cross_mark: **Routing**: none of the methods are protected from accessing due to lack of JWT token system.
  
  
### Core client-side UI
* Navigation is carried out using sidebar menu, also displaying profile data in the upper-left corner.
* Each navigation point opens corresponding feature module in the sidebar content area, modules are lazy-loaded. 
* Routes are protected with account Guards.


### Posts
* Client-side: 
  *  :heavy_check_mark: **Separation by digests**: done; posts are displayed under according tabs.
  *  :x: **Card UI model**: cards don't have styles; there are no links or buttons yet.
  *  :x: **Detailed Post view**: commented out in layout model; empty components created, but no logic or UI whatsoever.
  
* Server-side: 
  *  :heavy_check_mark: **Models and resources**: general entities are set up, each controller returns a specific view model (if required) without any sensitive or unneeded data.
  *  :heavy_check_mark: **Data ordering**: both "Get posts by digests" and "Get posts from all digests by user" methods are working and return sorted post lists as JSON responses.
  *  :x: **Data retrieval**: all the data is faked in the controllers; no database or backend interaction whatsoever.
  
  
###  Digests
* :x: Client-side: no work done yet. 
  *  :x: **Displaing user digests**:
  *  :x: **Creating new digests**: 
  *  :x: **Detailed Post view**:
  *  :x: **Editing digests**:
  *  :x: **Browsing for digests**:
  
* Server-side: 
  *  :negative_squared_cross_mark: **Digests domain model**: base models set up.
  *  :x: **Digests Controller methods and API endpoints**:
  *  :x: **Database interaction**:
  *  :x: **Separating public and private digests**:
  
  
###  Friends and user interaction
* :x: Client-side: no work done yet. 
  *  :x: **Displaing user profiles**:
  *  :x: **Separating public and private profile views**: 
  *  :x: **Editing your profile**:
  
* Server-side:
  *  :negative_squared_cross_mark: **Friends domain model**: base models set up.
  *  :negative_squared_cross_mark: **Separation of Account and Profile entities**: done via view models.
  *  :x: **Returning digests created and subscribed to by user**:
  
###  Global styles and settings 
*  :x: **CSS Styles and Themes**:
*  :x: **Transition to Flex Layout**: 
*  :x: **Returning digests created and subscribed to by user**:
*  :x: **Azure hosting**


