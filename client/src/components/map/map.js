import "react-map-gl-geocoder/dist/mapbox-gl-geocoder.css";
import React, ***REMOVED*** useEffect, useState, useRef, useCallback***REMOVED*** from "react";
import MapGL, ***REMOVED*** SVGOverlay, Marker***REMOVED*** from "react-map-gl";
import Geocoder from "react-map-gl-geocoder";
import ***REMOVED*** FlyToInterpolator, NavigationControl***REMOVED*** from "react-map-gl";
import * as Locations from "./locations";
import ***REMOVED*** Container***REMOVED*** from "react-bootstrap";
import Goo from "./goo";
import "mapbox-gl/dist/mapbox-gl.css";
import ***REMOVED*** ReactComponent as Pin***REMOVED*** from "../../assets/media/icons/pin-icon.svg";
//import DeckGL, ***REMOVED*** ScatterplotLayer***REMOVED*** from "deck.gl";

const ***REMOVED*** REACT_APP_TOKEN***REMOVED*** = process.env;

const Map = () => ***REMOVED***
  const [viewport, setViewport] = useState(***REMOVED***
    latitude: Locations.nyc.location.latitude,
    longitude: Locations.nyc.location.longitude,
    pitch: 60,
    bearing: 0.7,
    zoom: 11,
 ***REMOVED***);
  const mapRef = useRef();

  const handleViewportChange = useCallback(
    (newViewport) => setViewport(newViewport),
    []
  );

  const [data, setAirData] = useState([]);
  useEffect(() => ***REMOVED***
    setAirData(Locations.data);
    console.log(Locations.data);
 ***REMOVED***, []);

  // Custom settings for ViewportChange
  const handleGeocoderViewportChange = useCallback(
    (newViewport) => ***REMOVED***
      const geocoderDefaultOverrides = ***REMOVED***
        transitionDuration: 2000,
        pitch: 67,
        bearing: 0.7,
        transitionInterpolator: new FlyToInterpolator(),
     ***REMOVED***;

      return handleViewportChange(***REMOVED***
        ...newViewport,
        ...geocoderDefaultOverrides,
     ***REMOVED***);
   ***REMOVED***,
    [handleViewportChange]
  );
  
  const [markers, setMarkers] = React.useState([]);
  const handleClick = (***REMOVED*** lngLat: [longitude, latitude]***REMOVED***) =>
    setMarkers((markers) => [...markers, ***REMOVED*** longitude, latitude***REMOVED***]);

  return (
    <Container fluid style=***REMOVED******REMOVED*** height: "85vh", width: "90vw", marginLeft: "7.5vw", marginTop: "3vh"***REMOVED******REMOVED***>
      <MapGL
        ref=***REMOVED***mapRef***REMOVED***
        ***REMOVED***...viewport***REMOVED***
        width="100%"
        height="100%"
        onViewportChange=***REMOVED***handleViewportChange***REMOVED***
        mapboxApiAccessToken=***REMOVED***REACT_APP_TOKEN***REMOVED***
        onClick=***REMOVED***handleClick***REMOVED***
      >
        ***REMOVED***/* <DeckGL viewState=***REMOVED***viewport***REMOVED*** layers=***REMOVED***layers***REMOVED*** /> */***REMOVED***

        <SVGOverlayLayer airData=***REMOVED***data***REMOVED*** radius=***REMOVED***30***REMOVED*** color=***REMOVED***"#1cdaa3"***REMOVED*** />
        ***REMOVED***markers.map((m, i) => (
          <Marker ***REMOVED***...m***REMOVED*** key=***REMOVED***i***REMOVED*** offsetLeft=***REMOVED***-20***REMOVED*** offsetTop=***REMOVED***-30***REMOVED***>
            <Pin style=***REMOVED******REMOVED*** width: "40px"***REMOVED******REMOVED*** />
          </Marker>
        ))***REMOVED***

        <div style=***REMOVED******REMOVED*** position: "absolute", right: 10, top: 10***REMOVED******REMOVED***>
          <NavigationControl />
        </div>

        <Geocoder
          mapRef=***REMOVED***mapRef***REMOVED***
          onViewportChange=***REMOVED***handleGeocoderViewportChange***REMOVED***
          mapboxApiAccessToken=***REMOVED***REACT_APP_TOKEN***REMOVED***
          position="top-left"
        />
      </MapGL>
    </Container>
  );

  // const layers = [
  //     new ScatterplotLayer(***REMOVED***
  //       id: "scatterplot-layer",
  //       data: data,
  //       getRadius: 16 * 500,
  //       radiusMaxPixels: 18,
  //       getFillColor: [28, 218, 163],
  //       autoHighlight: true,
  //    ***REMOVED***),
  //   ];
***REMOVED***;

function SVGOverlayLayer(***REMOVED*** airData, radius, color***REMOVED***) ***REMOVED***
  const redraw = (***REMOVED*** project***REMOVED***) => ***REMOVED***
    return (
      <g>
        <Goo>
          ***REMOVED***airData.map((data) => ***REMOVED***
            const [x, y] = project(data.position);

            return (
              <circle
                key=***REMOVED***data.id***REMOVED***
                cx=***REMOVED***x***REMOVED***
                cy=***REMOVED***y***REMOVED***
                r=***REMOVED***radius***REMOVED***
                fill=***REMOVED***color***REMOVED***
                fillOpacity=***REMOVED***0.4***REMOVED***
                onClick=***REMOVED***() => ***REMOVED***
                  alert(
                    "The area location: (" + x + " - " + y + ") was clicked."
                  );
                  return false;
               ***REMOVED******REMOVED***
              />
            );
         ***REMOVED***)***REMOVED***
        </Goo>
      </g>
    );
 ***REMOVED***;

  return <SVGOverlay redraw=***REMOVED***redraw***REMOVED*** />;
***REMOVED***

export default Map;
