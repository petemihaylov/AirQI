# AirQi Overview

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

### Introduction

The AirQi application is used to visualise real-time insights into air quality index metrics.

AirQi is a distirbuted web application that integrates air quality data. Its aim is to empower users with real-time insights into air quality metrics, enabling informed decisions about their daily activities and overall health.
The AirQi web app is collecting, exposing, and visualizing air pollution data for specific regions as the goal is to improve the quality of living in the outdoor by informing the users about the health impacts and providing them with personalized suggestions. Our ultimate goal is to cultivate a sense of environmental consciousness, fostering a community that actively engages in improving air quality while ensuring that our visualizations are universally accessible.

### Tech

AirQi uses a number of open source libraries/frameworks to work properly:

* SignalR - Incredibly simple real-time web for ASPdotNet
* Redux - A Predictable State Container for JS Apps
* DeckGL - WebGL-powered framework for visual exploratory data analysis of large datasets.
* Hangfire - Background processing in .NET and .NET Core applications.
* .NetCore - Cross-platform, open-source developer platform.
* React - Creates interactive UIs.
* Node.js - Evented I/O for the backend.
* jQuery - Designed to simplify HTML DOM tree.
* Kubernetes - Open-source system for automating deployment, scaling, and management of containerized applications.

### Installation

AirQi requires [Node.js](https://nodejs.org/) v4+ and .Net Core v3.1+ to run.

Install the dependencies and start the server and the client side.

Client ReactJS application
```sh
    $ cd Web/client
    $ npm i
    $ npm start
```

User Management system
```sh
    $ cd Core/ApiBase
    $ dotnet build
    $ dotnet run
```

Data Provider system
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
### Source Details

/api/stations

```json
{
  "id": "60076a29bd691e98a8bee122",
  "aqi": 28.0,
  "location": "Southport",
  "city": "Southport",
  "country": "Australia",
  "measurements": [
    {
      "parameter": "h",
      "value": 77.1,
      "unit": "µg/m³",
      "sourceName": "Air quality | Environment, land and water | Queensland Government"
    },
    {
      "parameter": "no2",
      "value": 1.9,
      "unit": "µg/m³",
      "sourceName": "Air quality | Environment, land and water | Queensland Government"
    },
    {
      "parameter": "o3",
      "value": 5.3,
      "unit": "µg/m³",
      "sourceName": "Air quality | Environment, land and water | Queensland Government"
    },
    {
      "parameter": "p",
      "value": 1018.3,
      "unit": "µg/m³",
      "sourceName": "Air quality | Environment, land and water | Queensland Government"
    },
    {
      "parameter": "pm10",
      "value": 19.0,
      "unit": "µg/m³",
      "sourceName": "Air quality | Environment, land and water | Queensland Government"
    },
    {
      "parameter": "pm25",
      "value": 28.0,
      "unit": "µg/m³",
      "sourceName": "Air quality | Environment, land and water | Queensland Government"
    },
    {
      "parameter": "r",
      "value": 0.3,
      "unit": "µg/m³",
      "sourceName": "Air quality | Environment, land and water | Queensland Government"
    },
    {
      "parameter": "t",
      "value": 22.4,
      "unit": "µg/m³",
      "sourceName": "Air quality | Environment, land and water | Queensland Government"
    },
    {
      "parameter": "w",
      "value": 1.4,
      "unit": "µg/m³",
      "sourceName": "Air quality | Environment, land and water | Queensland Government"
    },
    {
      "parameter": "wd",
      "value": 169.0,
      "unit": "µg/m³",
      "sourceName": "Air quality | Environment, land and water | Queensland Government"
    },
    {
      "parameter": "wg",
      "value": 6.0,
      "unit": "µg/m³",
      "sourceName": "Air quality | Environment, land and water | Queensland Government"
    }
  ],
  "position": [ 153.402, -27.9612 ],
  "createdAt": "2021-01-19T23:24:25.687Z",
  "updatedAt": "2021-01-19T23:24:25.687Z"
}
```

/api/measurements
```json
{
  "id": "60075c54bd691e98a8bedc0d",
  "aqi": 110.0,
  "measurements": [
    {
      "parameter": "o3",
      "value": 191.0,
      "lastUpdated": "19/03/2019 07:00:00",
      "unit": "µg/m³",
      "sourceName": "ChinaAQIData"
    },
  ],
  "position": [ 117.1837, 39.2133 ],
  "createdAt": "2021-01-19T22:25:24.552Z",
  "updatedAt": "2021-01-19T22:25:24.553Z"
}
```

## Licenses
AirQi repo typically uses either the [MIT](LICENSE.TXT) or
[Apache 2](https://www.apache.org/licenses/LICENSE-2.0) licenses for code.
Some projects license documentation and other forms of content under
[Creative Commons Attribution 4.0](https://creativecommons.org/licenses/by/4.0/).

