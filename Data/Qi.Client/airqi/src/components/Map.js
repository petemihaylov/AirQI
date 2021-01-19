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

  const [hubConnection, setHubConnection] = useState(null);
    
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
    latitude: 50.8503,
    longitude: 52.3517,
    width: "100vw",
    height: "100vh",
    zoom: 12
  });

  const scatterplotlayer = [
    new ScatterplotLayer({
      id: "scatterplot-layer",
        data: data,
        getRadius: 18 * 500,
        radiusMaxPixels: 30,
        getFillColor: [28, 218, 163, 110],
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
      getSize: 18,
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

        {stations.map(function (station, index) {
            return (
              <Marker key={index} latitude={station.position[1]} longitude={station.position[0]}>
                <Pin />
              </Marker>
            );
        })}
        
        <DeckGL initialViewState={viewport}
          height={viewport.height}
          width={viewport.width}
          controller={true}
          layers={[scatterplotlayer, textLayer]}
        />

      </ReactMapGL>
        
    </div>
  );

}