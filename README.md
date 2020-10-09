# AirQI


### Introduction

**An air quality index (AQI)** is used to communicate to the public how polluted the air currently is or how polluted it is forecast to become. Public health risks increase as the AQI rises. Different countries have their own air quality indices, corresponding to different national air quality standards.
The idea of this project is to visualize real-time data from the measurements at meteorological stations or other AQI public APIs. 


Curretly we are using **JIRA** as a tool in order to use SCRUM methodology and all of the Agile's philosophical principles and values. In **Confluence** you can see most of our documentation and planning.

[JIRA](https://petarmihaylov.atlassian.net/secure/RapidBoard.jspa?projectKey=AIR&rapidView=1&view=planning.nodetail&atlOrigin=eyJpIjoiYWI1M2M1YWVmMmIyNGJkYmIwYWRiNjFlMGE4NmRlOTYiLCJwIjoiaiJ9)

[Confluence](https://petarmihaylov.atlassian.net/l/c/QEGg4x6G)

```json
{
    "_id":  "5f7c732d7be30a600ae8433b",
    "city": "New York",
    "country": {
        "name" : "United States",
        "code" : "US"
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
    "createdAt":"2020-05-09T22:00:00.000+00:00",
    "updatedAt":  "2020-05-09T22:00:00.000+00:00"
    
}
```