/// app.js
import useSwr from "swr";
import DeckGL, ***REMOVED*** ScatterplotLayer, TextLayer***REMOVED*** from "deck.gl";
// import ***REMOVED***LineLayer***REMOVED*** from '@deck.gl/layers';
import React, ***REMOVED*** useState***REMOVED*** from 'react';
import ReactMapGL from 'react-map-gl';

// Data fetching method
const fetcher = (...args) => fetch(...args).then(response => response.json());

// Viewport settings
const INITIAL_VIEW_STATE = ***REMOVED***
  longitude: 50.8503,
  latitude: 52.3517,
  zoom: 8,
  pitch: 0,
  bearing: 0
***REMOVED***;


export default function Map() ***REMOVED***
  // Viewport settings
  const [viewport, setViewport] = useState(***REMOVED***
    latitude: 50.8503,
    longitude: 52.3517,
    width: "100vw",
    height: "100vh",
    zoom: 12
 ***REMOVED***);

  // Load and prepare data
  const ***REMOVED*** stations, error***REMOVED*** = useSwr(process.env.REACT_APP_API_URL + "api/stations", fetcher);
  const data = (stations && !error) ? stations : [];
  console.log(stations);
  console.log(data);

  const scatterplotlayer = [
    new ScatterplotLayer(***REMOVED***
        id: "scatterplot-layer",
        opacity: 0.6,
        data: data.position,
        getRadius: 20 * 500,
        radiusMaxPixels: 18,
        getFillColor: [28, 218, 163],
        autoHighlight: true,
     ***REMOVED***)
  ];
  
  const textLayer = [
    new TextLayer(***REMOVED***
      id: 'text-layer',
      data,
      pickable: true,
      getPosition: d => d.position,
      getText: d => "aqi",
      getSize: 20,
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

        <DeckGL initialViewState=***REMOVED***INITIAL_VIEW_STATE***REMOVED*** controller=***REMOVED***true***REMOVED*** layers=***REMOVED***[scatterplotlayer, textLayer]***REMOVED*** getTooltip=***REMOVED***(***REMOVED***object***REMOVED***) => object && `$***REMOVED***object.name***REMOVED***\n$***REMOVED***object.address***REMOVED***`***REMOVED***/>

      </ReactMapGL>
        
    </div>
  );

***REMOVED***