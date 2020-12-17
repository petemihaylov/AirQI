/// app.js
import useSwr from "swr";
import React, { useState } from 'react';
import { Container } from 'reactstrap';
import ReactMapGL, { Marker, Popup } from 'react-map-gl';
import { ReactComponent as Pin } from "../assets/media/pin-icon.svg";

// Data fetching method
const fetcher = (...args) => fetch(...args).then(response => response.json());

// DeckGL react component
export default function Map() {
  // Viewport settings
  const [viewport, setViewport] = useState({
    latitude: 51.442089,
    longitude: 5.475200,
    width: "100vw",
    height: "100vh",
    zoom: 12
  });

  // Load and prepare data
  const { data, error } = useSwr(process.env.REACT_APP_API_URL + "api/stations", fetcher);
  const stations = (data && !error) ? data : [];
  
  return (
    <Container>
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
            <Marker key={index} latitude={station.coordinates.latitude} longitude={station.coordinates.longitude}>
              <Pin />
            </Marker>
          );
        })}

      </ReactMapGL>
        
    </Container>
  );

}