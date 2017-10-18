# Assessment

This is my modest take on a front-end for managing clients.

## Set-up
The application consists of two tiers, the server written in .NET core 1.1 and the client written in Angular 1.x. To start you will need:

* A Mongo database running locally
* Some utility to run an http server (npm install -g http-server)
* Chrome (dates do not display correctly in other browsers)
* .NET core framework

To run the server execute the following from the *api* directory:

* dotnet restore
* dotnet run

To test execute the following from the *api.test* directory:

* dotnet test

To run the client execute from the *client2* directory. It will typically run on port 8080

* http-server (from the client2 directory)
