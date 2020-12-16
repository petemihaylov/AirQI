/// app.js
import React from 'react';
import DeckGL from '@deck.gl/react';
import ***REMOVED*** LineLayer***REMOVED*** from '@deck.gl/layers';
import ***REMOVED***StaticMap***REMOVED*** from 'react-map-gl';

// Set your mapbox access token here
const MAPBOX_ACCESS_TOKEN = 'pk.eyJ1IjoicGVwc20iLCJhIjoiY2tobDQxZ2VxMGN2aDJzbG5raXJoN2VqcSJ9.ttIT-eWF2PYMSdxfZxk3Xw';

// Viewport settings
const INITIAL_VIEW_STATE = ***REMOVED***
  longitude: -122.41669,
  latitude: 37.7853,
  zoom: 13,
  pitch: 0,
  bearing: 0
***REMOVED***;

// Data to be used by the LineLayer
const data = [
  ***REMOVED***sourcePosition: [-122.41669, 37.7853], targetPosition: [-122.41669, 37.781]***REMOVED***
];

// DeckGL react component
export default function Map() ***REMOVED***
  const layers = [
    new LineLayer(***REMOVED***id: 'line-layer', data***REMOVED***)
  ];

  return <DeckGL
      initialViewState=***REMOVED***INITIAL_VIEW_STATE***REMOVED***
      controller=***REMOVED***true***REMOVED***
      layers=***REMOVED***layers***REMOVED***>

        <StaticMap mapboxApiAccessToken=***REMOVED***MAPBOX_ACCESS_TOKEN***REMOVED*** />
      </DeckGL>
***REMOVED***