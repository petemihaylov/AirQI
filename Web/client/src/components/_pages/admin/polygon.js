import React, ***REMOVED*** useEffect, useState, useRef, useCallback***REMOVED*** from "react";
import ***REMOVED*** Container***REMOVED*** from "react-bootstrap";
import MapGL, ***REMOVED*** NavigationControl***REMOVED*** from "react-map-gl";
import ***REMOVED*** Editor, DrawPolygonMode, EditingMode***REMOVED*** from "react-map-gl-draw";
import ***REMOVED*** faDrawPolygon, faSlidersH***REMOVED*** from "@fortawesome/free-solid-svg-icons";
import ***REMOVED*** FontAwesomeIcon***REMOVED*** from "@fortawesome/react-fontawesome";

import ***REMOVED*** customFeatureStyle, customHandleStyle***REMOVED*** from "./polygon-style";
const DEFAULT_VIEWPORT = ***REMOVED***
  latitude: 52.3676,
  longitude: 4.9041,
  pitch: 60,
  bearing: 0.7,
  zoom: 11,
***REMOVED***;

const Polygon = (props) => ***REMOVED***
  const ***REMOVED*** REACT_APP_TOKEN***REMOVED*** = process.env;
  const mapRef = useRef();

  const [viewport, setViewport] = useState(DEFAULT_VIEWPORT);
  const [modeHandler, setMode] = useState(null);
  const [features, setFeatures] = useState([]);

  const handleUpdate = (val) => ***REMOVED***
    setFeatures(val.data);
 ***REMOVED***;


  const hanldeSelect = (val) => ***REMOVED***
      console.log(val);
 ***REMOVED***
  const handleViewportChange = useCallback(
    (newViewport) => setViewport(newViewport),
    []
  );

  const _renderToolbar = () => ***REMOVED***
    return (
      <div>
        <div style=***REMOVED******REMOVED*** position: "absolute", right: 10, top: 10***REMOVED******REMOVED***>
          <NavigationControl />
        </div>
        <div
          className="mapboxgl-ctrl-group mapboxgl-ctrl"
          style=***REMOVED******REMOVED*** position: "absolute", left: 10, top: 10***REMOVED******REMOVED***
        >
          <button>
            <FontAwesomeIcon
              icon=***REMOVED***faDrawPolygon***REMOVED***
              onClick=***REMOVED***() => setMode(new DrawPolygonMode())***REMOVED***
            />
          </button>
        </div>
        <div
          className="mapboxgl-ctrl-group mapboxgl-ctrl"
          style=***REMOVED******REMOVED*** position: "absolute", left: 10, top: 50***REMOVED******REMOVED***
        >
          <button>
            <FontAwesomeIcon
              icon=***REMOVED***faSlidersH***REMOVED***
              onClick=***REMOVED***() => setMode(new EditingMode())***REMOVED***
            />
          </button>
        </div>
      </div>
    );
 ***REMOVED***;

  return (
    <Container
      style=***REMOVED******REMOVED***
        height: "56vh",
        marginTop: "1vh",
        padding: "0",
        width: "100%",
     ***REMOVED******REMOVED***
    >
      <MapGL
        ref=***REMOVED***mapRef***REMOVED***
        ***REMOVED***...viewport***REMOVED***
        width="100%"
        height="100%"
        onViewportChange=***REMOVED***handleViewportChange***REMOVED***
        mapStyle="mapbox://styles/constantimi/ckisx2s921doh19sz2tyod230"
        mapboxApiAccessToken=***REMOVED***REACT_APP_TOKEN***REMOVED***
      >
        <Editor
          clickRadius=***REMOVED***12***REMOVED***
          mode=***REMOVED***modeHandler***REMOVED***
          featureStyle=***REMOVED***customFeatureStyle***REMOVED***
          editHandleStyle=***REMOVED***customHandleStyle***REMOVED***
          onUpdate=***REMOVED***handleUpdate***REMOVED***
          onSelect=***REMOVED***hanldeSelect***REMOVED***
          features=***REMOVED***features***REMOVED***
        />
        ***REMOVED***_renderToolbar()***REMOVED***
      </MapGL>
    </Container>
  );
***REMOVED***;

export default Polygon;
