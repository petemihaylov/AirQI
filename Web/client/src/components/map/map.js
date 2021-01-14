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
import ***REMOVED***
  fetchMarkers,
  createMarker,
  deleteMarker,
***REMOVED*** from "../../actions/markerActions";
import ***REMOVED*** HubConnectionBuilder***REMOVED*** from "@microsoft/signalr";
import authHeader from "../../services/auth.header";
import MarkerEntity from "../../entities/Marker";
import ***REMOVED***
  faMapPin,
  faFire,
  faSmog,
  faTrashAlt,
  faCloudRain,
***REMOVED*** from "@fortawesome/free-solid-svg-icons";
import ***REMOVED*** FontAwesomeIcon***REMOVED*** from "@fortawesome/react-fontawesome";

/* Uncomment the code below */
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
          connection.on("GetNewMarker", (Marker) => ***REMOVED***
            setMarkers((markers) => [...markers, Marker]);
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
    setController(true);
    setShowPopup(false);
    enableAddMarker(false);
 ***REMOVED***;

  const handleClick = (***REMOVED*** lngLat: [longitude, latitude]***REMOVED***) => ***REMOVED***
    if (controllerSelect) ***REMOVED***
      if (addMarker) ***REMOVED***
        setShowPopup(true);
        setPopups([***REMOVED*** longitude, latitude***REMOVED***]);
     ***REMOVED***
      enableAddMarker(true);
   ***REMOVED***
 ***REMOVED***;

  const handleDelete = (obj) => () => ***REMOVED***
    if (eraseMarker) ***REMOVED***
      props.dispatch(deleteMarker(obj.marker.id, obj.index));
      enableEraseMarker(false);
   ***REMOVED***
 ***REMOVED***;

  const handleCreate = (longitude, latitude, ico) => ***REMOVED***
    const m = new MarkerEntity(longitude, latitude, "marker", JSON.stringify(ico));
    props.dispatch(createMarker(m));
    setShowPopup(false);
    enableAddMarker(false);
    setController(false);
 ***REMOVED***;

  /* Popup */
  const [popups, setPopups] = useState([]);
  const [controllerSelect, setController] = useState(false);
  const [showPopup, setShowPopup] = useState(false);
  const [addMarker, enableAddMarker] = useState(false);
  const [eraseMarker, enableEraseMarker] = useState(false);

  const _renderMarkerTools = () => ***REMOVED***
    return (
      <div
        className="mapboxgl-ctrl-top-right"
        style=***REMOVED******REMOVED*** position: "absolute", top: 140***REMOVED******REMOVED***
      >
        <div className="mapboxgl-ctrl-group mapboxgl-ctrl">
          <button className="" title="Add marker" onClick=***REMOVED***handleController***REMOVED***>
            <FontAwesomeIcon icon=***REMOVED***faMapPin***REMOVED*** />
          </button>
        </div>
        <div className="mapboxgl-ctrl-group mapboxgl-ctrl">
          <button
            className=""
            title="Delete marker"
            onClick=***REMOVED***() => ***REMOVED***
              enableEraseMarker(true);
              setShowPopup(false);
              setController(false);
           ***REMOVED******REMOVED***
          >
            <FontAwesomeIcon icon=***REMOVED***faTrashAlt***REMOVED*** />
          </button>
        </div>
      </div>
    );
 ***REMOVED***;

  const _renderMarkers = () => ***REMOVED***
    
    return markers.map((m, i) => (
      <Marker ***REMOVED***...m***REMOVED*** key=***REMOVED***i***REMOVED*** offsetLeft=***REMOVED***-20***REMOVED*** offsetTop=***REMOVED***-30***REMOVED***>
        <FontAwesomeIcon
          icon=***REMOVED***JSON.parse(m.ico)***REMOVED***
          onClick=***REMOVED***handleDelete(***REMOVED*** marker: m, index: i***REMOVED***)***REMOVED***
          style=***REMOVED******REMOVED*** fontSize: "20px", color: "#3a3a3a"***REMOVED******REMOVED***
        />***REMOVED***" "***REMOVED***
      </Marker>
    ));
 ***REMOVED***;

  const _renderMapTools = () => ***REMOVED***
    return (
      <div>
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
      </div>
    );
 ***REMOVED***;

  const _renderPopup = () => ***REMOVED***
    return (
      showPopup &&
      popups.map((p, i) => (
        <Popup
          latitude=***REMOVED***p.latitude***REMOVED***
          longitude=***REMOVED***p.longitude***REMOVED***
          closeButton=***REMOVED***false***REMOVED***
          closeOnClick=***REMOVED***true***REMOVED***
          anchor="bottom"
          key=***REMOVED***i***REMOVED***
        >
          <div className="p-2 ">
            <small>Pin and notify the others</small>
            <div className="d-flex justify-content-around mt-2 mb3">
              <button
                className="btn btn-info btn-sm mt-2 mr-2"
                onClick=***REMOVED***() => handleCreate(p.longitude, p.latitude, faSmog)***REMOVED***
              >
                <FontAwesomeIcon icon=***REMOVED***faSmog***REMOVED*** />
              </button>

              <button
                className="btn btn-dark btn-sm mt-2 mr-2"
                onClick=***REMOVED***() =>
                  handleCreate(p.longitude, p.latitude, faCloudRain)
               ***REMOVED***
              >
                <FontAwesomeIcon icon=***REMOVED***faCloudRain***REMOVED*** />
              </button>
              <button
                className="btn btn-danger btn-sm mt-2"
                onClick=***REMOVED***() => handleCreate(p.longitude, p.latitude, faFire)***REMOVED***
              >
                <FontAwesomeIcon icon=***REMOVED***faFire***REMOVED*** />
              </button>
            </div>
          </div>
        </Popup>
      ))
    );
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
        ***REMOVED***_renderMarkerTools()***REMOVED***
        ***REMOVED***_renderMapTools()***REMOVED***
        ***REMOVED***_renderPopup()***REMOVED***
      </MapGL>
    </Container>
  );
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

function mapStateToProps(state) ***REMOVED***
  const ***REMOVED*** items***REMOVED*** = state.markers;
  return ***REMOVED***
    items,
 ***REMOVED***;
***REMOVED***

export default connect(mapStateToProps)(Map);
