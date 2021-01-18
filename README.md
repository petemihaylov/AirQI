# AirQi Overview

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

### Introduction

An air quality index (AQI) is used to communicate to the public how polluted the air currently is or how polluted it is forecast to become. Public health risks increase as the AQI rises. All the different countries have their own air quality indices, corresponding to different national air quality standards. 

AirQi is a web platform that integrates air quality data and provides access to the latest information in the browser. The AirQi web app enables communities of citizens to set up an air monitoring network by collecting, publishing, and visualizing air pollution data for specific regions. With this app, our small team strives to improve the quality of living in the outdoor air-polluted regions by informing the users about the health impacts of various pollutants and providing them with personalized suggestions. 

### Tech

AirQi uses a number of open source libraries and frameworks to work properly:

* [.NetCore] - Open-source, managed computer software framework.  
* [ReactJS] - Creates interactive UIs.
* [node.js] - Evented I/O for the backend.
* [jQuery] - Designed to simplify HTML DOM tree.
* [Kubernetes] - Open-source system for automating deployment, scaling, and management of containerized applications.

### Dependencies

###### .NET Core Releases
* [Download the latest .NET Core SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
* [.NET Core releases](releases.md)

###### Downloading and installing Node.js and npm
* [Checking your version of npm and Node.js](https://docs.npmjs.com/downloading-and-installing-node-js-and-npm)
* [Using a Node version manager to install Node.js and npm](https://docs.npmjs.com/downloading-and-installing-node-js-and-npm)
* [Using a Node installer to install Node.js and npm](https://docs.npmjs.com/downloading-and-installing-node-js-and-npm)

### Packages

* [SignalR] - Incredibly simple real-time web for ASPdotNet
* [Redux] - A Predictable State Container for JS Apps
* [DeckGL] - WebGL-powered framework for visual exploratory data analysis of large datasets.
* [Hangfire] - Background processing in .NET and .NET Core applications.

### Installation

AirQi requires [Node.js](https://nodejs.org/) v4+ and .Net Core v3.1+ to run.

Install the dependencies and start the server and the client side.

[First Tab] Client ReactJS application
```sh
    $ cd Web/client
    $ npm i
    $ npm start
```

[Second Tab] User Management system
```sh
    $ cd Core/ApiBase
    $ dotnet build
    $ dotnet run
```

[Third Tab] Data Provider system
```sh
    $ cd Data/AirQi
    $ dotnet build 
    $ dotnet run
```
### Docker
AirQi is very easy to install and deploy in a Docker container.

By default, the Docker will expose port 8080, so change this within the Dockerfile if necessary. When ready, simply use the Dockerfile to build the image.

```sh
cd Web/client
docker build -t {youruser}/airqi:${package.json.version} .
```
This will create the image and pull in the necessary dependencies. Be sure to swap out `${package.json.version}` with the actual version of AirQi.

Once done, run the Docker image and map the port to whatever you wish on your host. In this example, we simply map port 8000 of the host to port 8080 of the Docker (or whatever port was exposed in the Dockerfile):

```sh
docker run -d -p 8000:8080 --restart="always" <youruser>/dillinger:${package.json.version}
```

Verify the deployment by navigating to your server address in your preferred browser.

```sh
127.0.0.1:8000
```
## Source Details

```json
{
  "_id": "5f7c732d7be30a600ae8433b",
  "city": "New York",
  "country": {
    "name": "United States",
    "code": "US"
  },
  "location": {
    "accuracy": 35.369,
    "latitude": 55.8256671,
    "longitude": 37.5962931
  },
  "measurements": [
    {
      "pm025": 15.32,
      "pm100": 26.47,
      "aqi": 67.67,
      "p": 94015.89,
      "h": 32.54,
      "t": 24.53,
      "o3": 16.63,
      "no2": 6.21
    }
  ],
  "createdAt": "2020-05-09T22:00:00.000+00:00",
  "updatedAt": "2020-05-09T22:00:00.000+00:00"
}
```

## Licenses
AirQi repo typically uses either the [MIT](LICENSE.TXT) or
[Apache 2](https://www.apache.org/licenses/LICENSE-2.0) licenses for code.
Some projects license documentation and other forms of content under
[Creative Commons Attribution 4.0](https://creativecommons.org/licenses/by/4.0/).




   [.NetCore]: <https://dotnet.microsoft.com/download/dotnet-core>
   [node.js]: <https://nodejs.org>
   [jQuery]: <https://jquery.com>
   [ReactJS]: <https://reactjs.org/>
   [SignalR]: <https://dotnet.microsoft.com/apps/aspnet/signalr>
   [Redux]: <https://redux.js.org/>
   [DeckGL]: <https://deck.gl/>
   [Hangfire]: <https://www.hangfire.io/>
   [Kubernetes]: <https://kubernetes.io/>

[[DevOps](https://dev.azure.com/429937/AirQI%20Project)][[JIRA](https://petarmihaylov.atlassian.net/secure/RapidBoard.jspa?projectKey=AIR&rapidView=1&view=planning.nodetail&atlOrigin=eyJpIjoiYWI1M2M1YWVmMmIyNGJkYmIwYWRiNjFlMGE4NmRlOTYiLCJwIjoiaiJ9)][[Confluence](https://petarmihaylov.atlassian.net/l/c/QEGg4x6G)]

