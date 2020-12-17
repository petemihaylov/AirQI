import "react-map-gl-geocoder/dist/mapbox-gl-geocoder.css";
import React, ***REMOVED*** useEffect, useState, useRef, useCallback***REMOVED*** from "react";
import MapGL, ***REMOVED*** SVGOverlay, Marker***REMOVED*** from "react-map-gl";
import Geocoder from "react-map-gl-geocoder";
import ***REMOVED*** FlyToInterpolator, NavigationControl, Popup***REMOVED*** from "react-map-gl";
import * as Locations from "./locations";
import ***REMOVED*** Container***REMOVED*** from "react-bootstrap";
import Goo from "./goo";
import "mapbox-gl/dist/mapbox-gl.css";
import ***REMOVED*** ReactComponent as Pin***REMOVED*** from "../../assets/media/icons/pin-icon.svg";
import ***REMOVED*** connect***REMOVED*** from "react-redux";
import ***REMOVED*** fetchMarkers, createMarker***REMOVED*** from "../../actions/markerActions";
import ***REMOVED*** HubConnectionBuilder***REMOVED*** from "@microsoft/signalr";
import authHeader from "../../services/auth.header";
import MarkerEntity from "../../entities/Marker";

import DeckGL, ***REMOVED*** ScatterplotLayer***REMOVED*** from "deck.gl";

const ***REMOVED*** REACT_APP_TOKEN***REMOVED*** = process.env;
const ***REMOVED*** REACT_APP_API_URL***REMOVED*** = process.env;

const Map = (props) => ***REMOVED***
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
 ***REMOVED***, []);

  /* Custom settings for ViewportChange */
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

  // Live markers from the WebSocket
  const [connection, setConnection] = useState(null);

  /* Gets WebSocket marker */
  useEffect(() => ***REMOVED***
    const newConnection = new HubConnectionBuilder()
      .withUrl(REACT_APP_API_URL + "/livemarker", ***REMOVED***
        headers: authHeader(),
     ***REMOVED***)
      .withAutomaticReconnect()
      .build();

    setConnection(newConnection);
 ***REMOVED***, []);

  useEffect(() => ***REMOVED***
    if (connection) ***REMOVED***
      connection
        .start()
        .then((result) => ***REMOVED***
          console.log("Connected!");

          connection.on("GetNewMarker", (Marker) => ***REMOVED***
            handleMarker(Marker.longitude, Marker.latitude);
         ***REMOVED***);
       ***REMOVED***)
        .catch((e) => console.log("Connection failed: ", e));
   ***REMOVED***
 ***REMOVED***, [connection]);

  /* Stored markers from the DB */
  const [content, handleContent] = useState([]);

  /* Gets markers from DB */
  useEffect(() => ***REMOVED***
    props.dispatch(fetchMarkers());
 ***REMOVED***, []);

  useEffect(() => ***REMOVED***
    handleContent(props.items);
 ***REMOVED***, [props.items]);

  useEffect(() => ***REMOVED***
    content.map((m) => handleMarker(m.longitude, m.latitude));
 ***REMOVED***, [content]);

  /* Markers */
  const [markers, setMarkers] = useState([]);
  const handleMarker = (longitude, latitude) => ***REMOVED***
    setMarkers((markers) => [...markers, ***REMOVED*** longitude, latitude***REMOVED***]);
    setShowPopup(false);
 ***REMOVED***;

  /* Popup */
  const [popups, setPopups] = useState([]);
  const [showPopup, setShowPopup] = useState(true);

  const handleClick = (***REMOVED*** lngLat: [longitude, latitude]***REMOVED***) => ***REMOVED***
    setShowPopup(true);
    setPopups([***REMOVED*** longitude, latitude***REMOVED***]);
 ***REMOVED***;

  const handleCreate = (longitude, latitude) => ***REMOVED***
    const m = new MarkerEntity(longitude, latitude);
    props.dispatch(createMarker(m));

    console.log("create");
    handleMarker(longitude, latitude);
 ***REMOVED***;

  return (
    <Container
      fluid
      style=***REMOVED******REMOVED***
        height: "85vh",
        width: "90vw",
        marginLeft: "7.5vw",
        marginTop: "3vh",
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
        onClick=***REMOVED***handleClick***REMOVED***
      >
        ***REMOVED***/* <DeckGL viewState=***REMOVED***viewport***REMOVED*** layers=***REMOVED***layers***REMOVED*** /> */***REMOVED***

        <SVGOverlayLayer airData=***REMOVED***data***REMOVED*** radius=***REMOVED***30***REMOVED*** color=***REMOVED***""***REMOVED*** />
        ***REMOVED***markers.map((m, i) => (
          <Marker ***REMOVED***...m***REMOVED*** key=***REMOVED***i***REMOVED*** offsetLeft=***REMOVED***-20***REMOVED*** offsetTop=***REMOVED***-30***REMOVED***>
            <Pin style=***REMOVED******REMOVED*** width: "40px"***REMOVED******REMOVED*** />
          </Marker>
        ))***REMOVED***

        ***REMOVED***showPopup &&
          popups.map((p, i) => (
            <Popup
              key=***REMOVED***i***REMOVED***
              latitude=***REMOVED***p.latitude***REMOVED***
              longitude=***REMOVED***p.longitude***REMOVED***
              closeButton=***REMOVED***false***REMOVED***
              closeOnClick=***REMOVED***true***REMOVED***
              anchor="bottom"
            >
              <div className="p-2">
                <small>A warning will be created!</small>
                <button
                  className="btn btn-block btn-outline-dark btn-sm mt-2"
                  onClick=***REMOVED***() => handleCreate(p.longitude, p.latitude)***REMOVED***
                >
                  Pin
                </button>
              </div>
            </Popup>
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
          ***REMOVED***airData.map((data, index) => ***REMOVED***
            const [x, y] = project(data.position);
            if (index % 3 === 0) color = "#1daffe";
            else color = "#1cdaa3";

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

function mapStateToProps(state) ***REMOVED***
  const ***REMOVED*** items***REMOVED*** = state.markers;
  return ***REMOVED***
    items,
 ***REMOVED***;
***REMOVED***

export default connect(mapStateToProps)(Map);
