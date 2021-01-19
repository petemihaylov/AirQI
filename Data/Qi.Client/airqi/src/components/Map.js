/// app.js
import useSwr from "swr";
import DeckGL, { ScatterplotLayer, TextLayer } from "deck.gl";
// import {LineLayer} from '@deck.gl/layers';
import React, { useState } from 'react';
import ReactMapGL from 'react-map-gl';

// Data fetching method
const fetcher = (...args) => fetch(...args).then(response => response.json());

// Viewport settings
const INITIAL_VIEW_STATE = {
  longitude: 50.8503,
  latitude: 52.3517,
  zoom: 8,
  pitch: 0,
  bearing: 0
};


export default function Map() {
  // Viewport settings
  const [viewport, setViewport] = useState({
    latitude: 50.8503,
    longitude: 52.3517,
    width: "100vw",
    height: "100vh",
    zoom: 12
  });

  // Load and prepare data
  const { stations, error } = useSwr(process.env.REACT_APP_API_URL + "api/stations", fetcher);
  const data = (stations && !error) ? stations : [];
  console.log(stations);
  console.log(data);

  const scatterplotlayer = [
    new ScatterplotLayer({
        id: "scatterplot-layer",
        opacity: 0.6,
        data: data.position,
        getRadius: 20 * 500,
        radiusMaxPixels: 18,
        getFillColor: [28, 218, 163],
        autoHighlight: true,
      })
  ];
  
  const textLayer = [
    new TextLayer({
      id: 'text-layer',
      data,
      pickable: true,
      getPosition: d => d.position,
      getText: d => "aqi",
      getSize: 20,
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

        <DeckGL initialViewState={INITIAL_VIEW_STATE} controller={true} layers={[scatterplotlayer, textLayer]} getTooltip={({object}) => object && `${object.name}\n${object.address}`}/>

      </ReactMapGL>
        
    </div>
  );

}