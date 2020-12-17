/// app.js
import useSwr from "swr";
import React, ***REMOVED*** useState***REMOVED*** from 'react';
import ***REMOVED*** Container***REMOVED*** from 'reactstrap';
import ReactMapGL, ***REMOVED*** Marker, Popup***REMOVED*** from 'react-map-gl';
import ***REMOVED*** ReactComponent as Pin***REMOVED*** from "../assets/media/pin-icon.svg";

// Data fetching method
const fetcher = (...args) => fetch(...args).then(response => response.json());

// DeckGL react component
export default function Map() ***REMOVED***
  // Viewport settings
  const [viewport, setViewport] = useState(***REMOVED***
    latitude: 51.442089,
    longitude: 5.475200,
    width: "100vw",
    height: "100vh",
    zoom: 12
 ***REMOVED***);

  // Load and prepare data
  const ***REMOVED*** data, error***REMOVED*** = useSwr(process.env.REACT_APP_API_URL + "api/stations", fetcher);
  const stations = (data && !error) ? data : [];
  
  return (
    <Container>
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
            <Marker key=***REMOVED***index***REMOVED*** latitude=***REMOVED***station.coordinates.latitude***REMOVED*** longitude=***REMOVED***station.coordinates.longitude***REMOVED***>
              <Pin />
            </Marker>
          );
       ***REMOVED***)***REMOVED***

      </ReactMapGL>
        
    </Container>
  );

***REMOVED***