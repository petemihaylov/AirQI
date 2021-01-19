// DeckGl
import DeckGL, ***REMOVED*** ScatterplotLayer, TextLayer***REMOVED*** from "deck.gl";
// ReactJS
import useSwr from "swr";
import React, ***REMOVED*** useEffect, useState***REMOVED*** from 'react';
// Markers
import ReactMapGL, ***REMOVED*** Marker***REMOVED*** from 'react-map-gl';
import ***REMOVED*** ReactComponent as Pin***REMOVED*** from "../assets/media/pin-icon.svg";
// SignalR
import ***REMOVED*** HubConnectionBuilder***REMOVED*** from "@microsoft/signalr";


// Data fetching method
const fetcher = (...args) => fetch(...args).then(response => response.json());


export default function Map() ***REMOVED***

  const [hubConnection, setHubConnection] = useState(null);
    
  // Load and prepare data
  const ***REMOVED*** data, error***REMOVED*** = useSwr(process.env.REACT_APP_API_URL + "api/stations", fetcher);
  const stations = (data && !error) ? data : [];
  
  useEffect(() => ***REMOVED***
      // Create Hub Connection.
      const createHubConnection = async () => ***REMOVED***

          const hubConnect = new HubConnectionBuilder()
          .withUrl(process.env.REACT_APP_API_URL + "livestations")
          .withAutomaticReconnect()
          .build();
          
          // Set the initial SignalR Hub Connection.
          setHubConnection(hubConnect);
          
     ***REMOVED***

      createHubConnection();
 ***REMOVED***, []);
  
  // Websocket
  useEffect(() => ***REMOVED***

      const startHubConnection = async () => ***REMOVED***
          if (hubConnection) ***REMOVED***
              await hubConnection
                  .start()
                  .then((result) => ***REMOVED***
                      console.log("SignalR Connected!");

                      hubConnection.on("GetNewStationsAsync", (stations) => ***REMOVED***
                          console.log("New Updated Data");
                          console.log(stations);
                          this.stations = stations;
                     ***REMOVED***);
                 ***REMOVED***)
                  .catch((e) => console.log("Connection failed: ", e));
         ***REMOVED***
     ***REMOVED***
       
      startHubConnection();

 ***REMOVED***, [hubConnection]);

  // Viewport settings
  const [viewport, setViewport] = useState(***REMOVED***
    latitude: 50.8503,
    longitude: 52.3517,
    width: "100vw",
    height: "100vh",
    zoom: 12
 ***REMOVED***);

  const scatterplotlayer = [
    new ScatterplotLayer(***REMOVED***
      id: "scatterplot-layer",
        data: data,
        getRadius: 18 * 500,
        radiusMaxPixels: 30,
        getFillColor: [28, 218, 163, 110],
        autoHighlight: true,
     ***REMOVED***)
  ];
  
  const textLayer = [
    new TextLayer(***REMOVED***
      id: 'text-layer',
      data,
      pickable: true,
      getPosition: d => d.position,
      getText: d => `$***REMOVED***d.aqi***REMOVED***`,
      getSize: 18,
      getAngle: 0,
      getTextAnchor: 'middle',
      getAlignmentBaseline: 'center'
   ***REMOVED***)
  ];
  
  return (
    <div>
      <ReactMapGL
        ***REMOVED***...viewport***REMOVED***
        mapboxApiAccessToken=***REMOVED***process.env.REACT_APP_MAPBOX_TOKEN***REMOVED***
        mapStyle="mapbox://styles/constantimi/ckisx2s921doh19sz2tyod230"
        onViewportChange=***REMOVED***viewport => ***REMOVED***
          setViewport(viewport);
       ***REMOVED******REMOVED***
      >

        ***REMOVED***stations.map(function (station, index) ***REMOVED***
            return (
              <Marker key=***REMOVED***index***REMOVED*** latitude=***REMOVED***station.position[1]***REMOVED*** longitude=***REMOVED***station.position[0]***REMOVED***>
                <Pin />
              </Marker>
            );
       ***REMOVED***)***REMOVED***
        
        <DeckGL initialViewState=***REMOVED***viewport***REMOVED***
          height=***REMOVED***viewport.height***REMOVED***
          width=***REMOVED***viewport.width***REMOVED***
          controller=***REMOVED***true***REMOVED***
          layers=***REMOVED***[scatterplotlayer, textLayer]***REMOVED***
        />

      </ReactMapGL>
        
    </div>
  );

***REMOVED***