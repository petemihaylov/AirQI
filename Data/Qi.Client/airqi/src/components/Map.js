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

  // SignalR
  const [hubConnection, setHubConnection] = useState(null);
  const [zoom, setZoom] = useState(null);
    
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
    latitude: 52.3676,
    longitude: 4.9041,
    width: "100vw",
    height: "100vh",
    zoom: 6,
    minZoom: 3,
 ***REMOVED***);

  const changeColor = (aqi) => ***REMOVED***
    if (aqi >= 0 && aqi <= 50) ***REMOVED***
      return [162, 219, 96, 20];      
   ***REMOVED***
    
    if (aqi >= 51 && aqi <= 100) ***REMOVED***
      return [250, 213, 80, 20];      
   ***REMOVED***

    if (aqi >= 101 && aqi <= 150) ***REMOVED***
      return [253, 154, 87, 20];     
   ***REMOVED***

    if (aqi >= 151 && aqi <= 200) ***REMOVED***
      return [254, 104, 109, 20];      
   ***REMOVED***

    // Very Unhealthy
    if (aqi >= 201 && aqi <= 300) ***REMOVED***
      return [155, 89, 117, 20];      
   ***REMOVED***

    // Hazardous
    return [152, 86, 114, 20];  
 ***REMOVED***

  // DeckGl Layers
  const scatterplotlayer = [
    new ScatterplotLayer(***REMOVED***
        id: "scatterplot-layer",
        data: data,
        getRadius: zoom * 100,
        radiusMaxPixels: 100,
        radiusMinPixels: 20,
        getFillColor: d => changeColor(d.aqi),
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
      getSize: zoom + 8,
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
        
        <DeckGL initialViewState=***REMOVED***viewport***REMOVED***
          height=***REMOVED***viewport.height***REMOVED***
          width=***REMOVED***viewport.width***REMOVED***
          controller=***REMOVED***true***REMOVED***
          layers=***REMOVED***[scatterplotlayer, textLayer]***REMOVED***
          onViewStateChange=***REMOVED***(***REMOVED*** viewState***REMOVED***) => ***REMOVED***
            console.log(viewState);
            setZoom(viewState.zoom);
         ***REMOVED******REMOVED***
        />

      </ReactMapGL>
        
    </div>
  );

***REMOVED***