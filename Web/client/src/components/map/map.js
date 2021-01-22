import "react-map-gl-geocoder/dist/mapbox-gl-geocoder.css";
import React, ***REMOVED*** useEffect, useState, useRef, useCallback***REMOVED*** from "react";
import MapGL, ***REMOVED*** Marker, FullscreenControl, GeolocateControl***REMOVED*** from "react-map-gl";
import Geocoder from "react-map-gl-geocoder";
import ***REMOVED*** FlyToInterpolator, NavigationControl, Popup***REMOVED*** from "react-map-gl";
import ***REMOVED*** Container***REMOVED*** from "react-bootstrap";
import "mapbox-gl/dist/mapbox-gl.css";
import ***REMOVED*** connect***REMOVED*** from "react-redux";
import ***REMOVED*** createNotification***REMOVED*** from "../../actions/notificationActions";
import ***REMOVED*** HubConnectionBuilder***REMOVED*** from "@microsoft/signalr";
import authHeader from "../../services/auth.header";
import MarkerEntity from "../../entities/Marker";
import Notification from "../../entities/Notification";
import ***REMOVED*** FontAwesomeIcon***REMOVED*** from "@fortawesome/react-fontawesome";
import DeckGL, ***REMOVED*** ScatterplotLayer, TextLayer***REMOVED*** from "deck.gl";
import useSwr from "swr";

import ***REMOVED***
  faMapPin,
  faFire,
  faSmog,
  faTrashAlt,
  faCloudRain,
***REMOVED*** from "@fortawesome/free-solid-svg-icons";

import ***REMOVED***
  fetchMarkers,
  createMarker,
  deleteMarker,
***REMOVED*** from "../../actions/markerActions";
import ***REMOVED*** Legend***REMOVED*** from "../../assets/js/legend/legend";


// Data fetching method
const fetcher = (...args) => fetch(...args).then(response => response.json());

const ***REMOVED*** REACT_APP_TOKEN, REACT_APP_API_URL, REACT_APP_DATA_URL***REMOVED*** = process.env;


const Map = (props) => ***REMOVED***
  // Viewport settings
  const [viewport, setViewport] = useState(***REMOVED***
    latitude: 52.3676,
    longitude: 4.9041,
    width: "100vw",
    height: "100vh",
    pitch: 67,
    bearing: 0.7,
    zoom: 6,
    minZoom: 3
 ***REMOVED***);

  const mapRef = useRef();

  const handleViewportChange = useCallback((newViewport) => setViewport(newViewport),[]);

   /* SignalR */
   const [hubConnection, setHubConnection] = useState(null);
   const [zoom, setZoom] = useState(null);
     
   /* Load and prepare data */
   const ***REMOVED*** data, error***REMOVED*** = useSwr(REACT_APP_DATA_URL + "/api/stations", fetcher);
   const stations = (data && !error) ? data : [];
   
   useEffect(() => ***REMOVED***
       /* Create Hub Connection. */
       const createHubConnection = async () => ***REMOVED***
 
           const hubConnect = new HubConnectionBuilder()
           .withUrl(REACT_APP_DATA_URL + "/livestations")
           .withAutomaticReconnect()
           .build();
           
           /* Set the initial SignalR Hub Connection. */
           setHubConnection(hubConnect);
           
      ***REMOVED***
 
       createHubConnection();
  ***REMOVED***, []);
   
   /* Websocket */
   useEffect(() => ***REMOVED***
 
      
           if (hubConnection) ***REMOVED***
                hubConnection
                   .start()
                   .then((result) => ***REMOVED***
                       console.log("SignalR Connected!");
 
                       hubConnection.on("GetNewStationsAsync", (stations) => ***REMOVED***
                           console.log("New Updated Data");
                           console.log(stations);
                           this.stations = stations;
                      ***REMOVED***);
                  ***REMOVED***)
                   .catch((e) => console.log("Connection failed: ", e));
          ***REMOVED***
       
        
 
  ***REMOVED***, [hubConnection]);

  /* Custom settings for ViewportChange */
  const handleGeocoderViewportChange = useCallback(
    (newViewport) => ***REMOVED***
      const geocoderDefaultOverrides = ***REMOVED***
        transitionDuration: 2000,
        pitch: 80,
        bearing: 0.7,
        transitionInterpolator: new FlyToInterpolator(),
     ***REMOVED***;

      return handleViewportChange(***REMOVED***...newViewport, ...geocoderDefaultOverrides***REMOVED***);
   ***REMOVED***,
    [handleViewportChange]
  );

  /* Live markers from the WebSocket */
  const [connection, setConnection] = useState(null);

  useEffect(() => ***REMOVED***

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

  const handleCreate = (longitude, latitude, ico, message) => ***REMOVED***
    const m = new MarkerEntity(longitude, latitude, "marker", JSON.stringify(ico));
    props.dispatch(createMarker(m));

    const n = new Notification(message.title, message.description, "Marker", Date.now);
    props.dispatch(createNotification(n));
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
          style=***REMOVED******REMOVED*** fontSize: "20px", color: "#3a3a3a", cursor: "pointer"***REMOVED******REMOVED***
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
        <GeolocateControl
          style=***REMOVED******REMOVED***
            position: "absolute",
            right: 10,
            top: "29vh"
         ***REMOVED******REMOVED***
          positionOptions=***REMOVED******REMOVED*** enableHighAccuracy: true***REMOVED******REMOVED***
          trackUserLocation=***REMOVED***true***REMOVED***
          auto
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
                onClick=***REMOVED***() =>
                  handleCreate(p.longitude, p.latitude, faSmog, ***REMOVED***
                    title: "Smog",
                    description:
                      "Danger for people with emphysema, bronchitis, and asthma.",
                 ***REMOVED***)
               ***REMOVED***
              >
                <FontAwesomeIcon icon=***REMOVED***faSmog***REMOVED*** />
              </button>

              <button
                className="btn btn-dark btn-sm mt-2 mr-2"
                onClick=***REMOVED***() =>
                  handleCreate(p.longitude, p.latitude, faCloudRain, ***REMOVED***
                    title: "Heavy rainfall",
                    description:
                      "There is a risk of flooding and damaged infrastructure.",
                 ***REMOVED***)
               ***REMOVED***
              >
                <FontAwesomeIcon icon=***REMOVED***faCloudRain***REMOVED*** />
              </button>
              <button
                className="btn btn-danger btn-sm mt-2"
                onClick=***REMOVED***() =>
                  handleCreate(p.longitude, p.latitude, faFire, ***REMOVED***
                    title: "Danger of Fire",
                    description:
                      "It might have toxic gases, thick black smoke, and lack of oxygen.",
                 ***REMOVED***)
               ***REMOVED***
              >
                <FontAwesomeIcon icon=***REMOVED***faFire***REMOVED*** />
              </button>
            </div>
          </div>
        </Popup>
      ))
    );
 ***REMOVED***;

  const _changeColor = (aqi) => ***REMOVED***
      
    if (aqi >= 0 && aqi <= 25) ***REMOVED***
      return [69, 173, 218, 40];
   ***REMOVED***

    if (aqi >= 26 && aqi <= 50) ***REMOVED***
      return [162, 219, 96, 40];      
   ***REMOVED***
    
    if (aqi >= 51 && aqi <= 100) ***REMOVED***
      return [250, 213, 80, 40];      
   ***REMOVED***

    if (aqi >= 101 && aqi <= 150) ***REMOVED***
      return [253, 154, 87, 40];     
   ***REMOVED***

    if (aqi >= 151 && aqi <= 200) ***REMOVED***
      return [254, 104, 109, 40];      
   ***REMOVED***

    if (aqi >= 201 && aqi <= 300) ***REMOVED***
      return [155, 89, 117, 40];      
   ***REMOVED***

    return [152, 86, 114, 40];  
 ***REMOVED***

  // DeckGl Layers
  const scatterplotlayer = [
    new ScatterplotLayer(***REMOVED***
        id: "scatterplot-layer",
        data: stations,
        getRadius: zoom * 100,
        radiusMaxPixels: 100,
        radiusMinPixels: 20,
        getFillColor: d => _changeColor(d.aqi),
        autoHighlight: true,
     ***REMOVED***)
  ];
  
  const textLayer = [
    new TextLayer(***REMOVED***
      id: 'text-layer',
      data,
      pickable: true,
      getPosition: d => d.position,
      getText: d => `.`,
      getSize: zoom + 8,
      getAngle: 0,
      getTextAnchor: 'middle',
      getAlignmentBaseline: 'center'
   ***REMOVED***)
  ];

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
        
        <DeckGL initialViewState=***REMOVED***viewport***REMOVED***
          height=***REMOVED***viewport.height***REMOVED***
          width=***REMOVED***viewport.width***REMOVED***
          controller=***REMOVED***true***REMOVED***
          layers=***REMOVED***[scatterplotlayer, textLayer]***REMOVED***
          onViewStateChange=***REMOVED***(***REMOVED*** viewState***REMOVED***) => ***REMOVED***
            console.log(`state: $***REMOVED***viewState.zoom***REMOVED***`);
            setZoom(viewState.zoom);
         ***REMOVED******REMOVED***
        />

        ***REMOVED***_renderMarkers()***REMOVED***
        ***REMOVED***_renderMarkerTools()***REMOVED***
        ***REMOVED***_renderMapTools()***REMOVED***
        ***REMOVED***_renderPopup()***REMOVED***

        <Legend />

      </MapGL>
    </Container>
  );
***REMOVED***;


function mapStateToProps(state) ***REMOVED***
  const ***REMOVED*** items***REMOVED*** = state.markers;
  return ***REMOVED***
    items,
 ***REMOVED***;
***REMOVED***

export default connect(mapStateToProps)(Map);
