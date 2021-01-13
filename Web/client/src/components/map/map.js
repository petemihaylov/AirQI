import "react-map-gl-geocoder/dist/mapbox-gl-geocoder.css";
import React, ***REMOVED*** useEffect, useState, useRef, useCallback***REMOVED*** from "react";
import MapGL, ***REMOVED*** SVGOverlay, Marker, FullscreenControl***REMOVED*** from "react-map-gl";
import Geocoder from "react-map-gl-geocoder";
import ***REMOVED*** FlyToInterpolator, NavigationControl, Popup***REMOVED*** from "react-map-gl";
import * as Locations from "./locations";
import ***REMOVED*** Container***REMOVED*** from "react-bootstrap";
import Goo from "./goo";
import "mapbox-gl/dist/mapbox-gl.css";
import ***REMOVED*** ReactComponent as Pin***REMOVED*** from "../../assets/media/icons/pin-icon.svg";
import ***REMOVED*** connect***REMOVED*** from "react-redux";
import ***REMOVED*** fetchMarkers, createMarker, deleteMarker***REMOVED*** from "../../actions/markerActions";
import ***REMOVED*** HubConnectionBuilder***REMOVED*** from "@microsoft/signalr";
import authHeader from "../../services/auth.header";
import MarkerEntity from "../../entities/Marker";
import ***REMOVED***
  faMapPin,
  faFire,
  faSmog,
  faCloudRain,
***REMOVED*** from "@fortawesome/free-solid-svg-icons";
import ***REMOVED*** FontAwesomeIcon***REMOVED*** from "@fortawesome/react-fontawesome";

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

  const handleViewportChange = useCallback((newViewport) => setViewport(newViewport),[]);

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

  /* Live markers from the WebSocket */
  const [connection, setConnection] = useState(null);

  /* Mock up data */
  const [data, setAirData] = useState([]);

  useEffect(() => ***REMOVED***
    /* Sets the mockup data */
    setAirData(Locations.data);

    /* Gets markers from DB */
    props.dispatch(fetchMarkers());

    /* Gets WebSocket marker */
    const newConnection = new HubConnectionBuilder()
      .withUrl(REACT_APP_API_URL + "/livemarker", ***REMOVED***
        headers: authHeader(),
     ***REMOVED***)
      .withAutomaticReconnect()
      .build();

    setConnection(newConnection);
 ***REMOVED***, []);

  /* WebSocket connection */
  useEffect(() => ***REMOVED***
    if (connection) ***REMOVED***
      connection
        .start()
        .then((result) => ***REMOVED***
          console.log("Connected!");

          connection.on("GetNewMarker", (Marker) => ***REMOVED***
            setMarkers(markers => [...markers, Marker]);
         ***REMOVED***);
       ***REMOVED***)
        .catch((e) => console.log("Connection failed: ", e));
   ***REMOVED***
 ***REMOVED***, [connection]);




  /* Markers */
  const [markers, setMarkers] = useState([]);
  useEffect(() => ***REMOVED***
    setMarkers(props.items);
 ***REMOVED***, [props.items]);

  const handleController = () => ***REMOVED***
    setController(!controllerSelect);
    setShowPopup(false);
    setFeature(false);
 ***REMOVED***;

  const handleClick = (***REMOVED*** lngLat: [longitude, latitude]***REMOVED***) => ***REMOVED***
    if (controllerSelect) ***REMOVED***
      if (feature) ***REMOVED***
        setShowPopup(true);
        setPopups([***REMOVED*** longitude, latitude***REMOVED***]);
     ***REMOVED***
      setFeature(true);
   ***REMOVED***
 ***REMOVED***;

  const handleDelete = obj => () => ***REMOVED***
    props.dispatch(deleteMarker(obj.marker.id, obj.index));
 ***REMOVED***;

  const handleCreate = (longitude, latitude) => ***REMOVED***
    const m = new MarkerEntity(longitude, latitude);
    props.dispatch(createMarker(m));
    setShowPopup(false);
 ***REMOVED***;




  /* Popup */
  const [popups, setPopups] = useState([]);
  const [controllerSelect, setController] = useState(false);
  const [showPopup, setShowPopup] = useState(false);
  const [feature, setFeature] = useState(false);

  const _renderMarkerTool = () => ***REMOVED***
    return (
      <div
        className="mapboxgl-ctrl-top-right"
        style=***REMOVED******REMOVED*** position: "absolute",  top: 140***REMOVED******REMOVED***
      >
        <div className="mapboxgl-ctrl-group mapboxgl-ctrl">
          <button className="" title="Marker" onClick=***REMOVED***handleController***REMOVED***>
            <FontAwesomeIcon icon=***REMOVED***faMapPin***REMOVED*** />
          </button>
        </div>
      </div>
    );
 ***REMOVED***;

  const _renderMarkers = () => ***REMOVED***
    return markers.map((m, i) => (
      <Marker ***REMOVED***...m***REMOVED*** key=***REMOVED***i***REMOVED*** offsetLeft=***REMOVED***-20***REMOVED*** offsetTop=***REMOVED***-30***REMOVED***>
        <Pin onClick=***REMOVED***handleDelete(***REMOVED***marker: m, index: i***REMOVED***)***REMOVED*** style=***REMOVED******REMOVED*** width: "40px"***REMOVED******REMOVED*** />
      </Marker>
    ));
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

        ***REMOVED***_renderMarkers()***REMOVED***
        ***REMOVED***_renderMarkerTool()***REMOVED***

        ***REMOVED***showPopup &&
          popups.map((p, i) => (
            <Popup
              latitude=***REMOVED***p.latitude***REMOVED***
              longitude=***REMOVED***p.longitude***REMOVED***
              closeButton=***REMOVED***false***REMOVED***
              closeOnClick=***REMOVED***true***REMOVED***
              anchor="bottom"
              key=***REMOVED***i***REMOVED***
            >
              <div className="p-2">
                <small>A warning will be created!</small>

                <div
                  style=***REMOVED******REMOVED*** height: "50px", overflowY: "auto"***REMOVED******REMOVED***
                  className="mt-2 mb-2"
                >
                  <div className="d-flex justify-content-around">
                    <FontAwesomeIcon icon=***REMOVED***faFire***REMOVED*** /> Fire
                  </div>
                  <div className="d-flex justify-content-around">
                    <FontAwesomeIcon icon=***REMOVED***faSmog***REMOVED*** /> Smog
                  </div>
                  <div className="d-flex justify-content-around">
                    <FontAwesomeIcon icon=***REMOVED***faCloudRain***REMOVED*** />
                    Clouds
                  </div>
                  <div className="d-flex justify-content-around">
                    <FontAwesomeIcon icon=***REMOVED***faFire***REMOVED*** /> Fire
                  </div>
                  <div className="d-flex justify-content-around">
                    <FontAwesomeIcon icon=***REMOVED***faSmog***REMOVED*** /> Smog
                  </div>
                  <div className="d-flex justify-content-around">
                    <FontAwesomeIcon icon=***REMOVED***faCloudRain***REMOVED*** />
                    Clouds
                  </div>
                </div>

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
        <div style=***REMOVED******REMOVED*** position: "absolute", right: 10, top: 110***REMOVED******REMOVED***>
          <FullscreenControl />
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
