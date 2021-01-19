// DeckGl
import DeckGL, { ScatterplotLayer, TextLayer } from "deck.gl";
// ReactJS
import useSwr from "swr";
import React, { useEffect, useState } from 'react';
// Markers
import ReactMapGL, { Marker } from 'react-map-gl';
import { ReactComponent as Pin } from "../assets/media/pin-icon.svg";
// SignalR
import { HubConnectionBuilder } from "@microsoft/signalr";


// Data fetching method
const fetcher = (...args) => fetch(...args).then(response => response.json());


export default function Map() {

  // SignalR
  const [hubConnection, setHubConnection] = useState(null);
  const [zoom, setZoom] = useState(null);
    
  // Load and prepare data
  const { data, error } = useSwr(process.env.REACT_APP_API_URL + "api/stations", fetcher);
  const stations = (data && !error) ? data : [];
  
  useEffect(() => {
      // Create Hub Connection.
      const createHubConnection = async () => {

          const hubConnect = new HubConnectionBuilder()
          .withUrl(process.env.REACT_APP_API_URL + "livestations")
          .withAutomaticReconnect()
          .build();
          
          // Set the initial SignalR Hub Connection.
          setHubConnection(hubConnect);
          
      }

      createHubConnection();
  }, []);
  
  // Websocket
  useEffect(() => {

      const startHubConnection = async () => {
          if (hubConnection) {
              await hubConnection
                  .start()
                  .then((result) => {
                      console.log("SignalR Connected!");

                      hubConnection.on("GetNewStationsAsync", (stations) => {
                          console.log("New Updated Data");
                          console.log(stations);
                          this.stations = stations;
                      });
                  })
                  .catch((e) => console.log("Connection failed: ", e));
          }
      }
       
      startHubConnection();

  }, [hubConnection]);

  // Viewport settings
  const [viewport, setViewport] = useState({
    latitude: 52.3676,
    longitude: 4.9041,
    width: "100vw",
    height: "100vh",
    zoom: 6,
    minZoom: 3,
  });

  const changeColor = (aqi) => {
    if (aqi >= 0 && aqi <= 50) {
      return [162, 219, 96, 20];      
    }
    
    if (aqi >= 51 && aqi <= 100) {
      return [250, 213, 80, 20];      
    }

    if (aqi >= 101 && aqi <= 150) {
      return [253, 154, 87, 20];     
    }

    if (aqi >= 151 && aqi <= 200) {
      return [254, 104, 109, 20];      
    }

    // Very Unhealthy
    if (aqi >= 201 && aqi <= 300) {
      return [155, 89, 117, 20];      
    }

    // Hazardous
    return [152, 86, 114, 20];  
  }

  // DeckGl Layers
  const scatterplotlayer = [
    new ScatterplotLayer({
        id: "scatterplot-layer",
        data: data,
        getRadius: zoom * 100,
        radiusMaxPixels: 100,
        radiusMinPixels: 20,
        getFillColor: d => changeColor(d.aqi),
        autoHighlight: true,
      })
  ];
  
  const textLayer = [
    new TextLayer({
      id: 'text-layer',
      data,
      pickable: true,
      getPosition: d => d.position,
      getText: d => `${d.aqi}`,
      getSize: zoom + 8,
      getAngle: 0,
      getTextAnchor: 'middle',
      getAlignmentBaseline: 'center'
    })
  ];
  

  return (
    <div>
      <ReactMapGL
        {...viewport}
        mapboxApiAccessToken={process.env.REACT_APP_MAPBOX_TOKEN}
        mapStyle="mapbox://styles/constantimi/ckisx2s921doh19sz2tyod230"
        onViewportChange={viewport => {
          setViewport(viewport);
        }}
      >
        
        <DeckGL initialViewState={viewport}
          height={viewport.height}
          width={viewport.width}
          controller={true}
          layers={[scatterplotlayer, textLayer]}
          onViewStateChange={({ viewState }) => {
            console.log(viewState);
            setZoom(viewState.zoom);
          }}
        />

      </ReactMapGL>
        
    </div>
  );

}