import "react-map-gl-geocoder/dist/mapbox-gl-geocoder.css";
import React, { useEffect, useState, useRef, useCallback } from "react";
import MapGL, { Marker, FullscreenControl, GeolocateControl } from "react-map-gl";
import Geocoder from "react-map-gl-geocoder";
import { FlyToInterpolator, NavigationControl, Popup } from "react-map-gl";
import { Container } from "react-bootstrap";
import DeckGLMap from "./deckgl";
import "mapbox-gl/dist/mapbox-gl.css";
import { connect } from "react-redux";
import {
  fetchMarkers,
  createMarker,
  deleteMarker,
} from "../../actions/markerActions";
import {
  createNotification,
} from "../../actions/notificationActions";
import { HubConnectionBuilder } from "@microsoft/signalr";
import authHeader from "../../services/auth.header";
import MarkerEntity from "../../entities/Marker";
import Notification from "../../entities/Notification";
import {
  faMapPin,
  faFire,
  faSmog,
  faTrashAlt,
  faCloudRain,
} from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

import DeckGL, { ScatterplotLayer, TextLayer } from "deck.gl";
import useSwr from "swr";


// Data fetching method
const fetcher = (...args) => fetch(...args).then(response => response.json());

const { REACT_APP_TOKEN } = process.env;
const { REACT_APP_API_URL } = process.env;
const {REACT_APP_DATA_URL} = process.env;

const Map = (props) => {
  // Viewport settings
  const [viewport, setViewport] = useState({
    latitude: 52.3676,
    longitude: 4.9041,
    width: "100vw",
    height: "100vh",
    pitch: 67,
    bearing: 0.7,
    zoom: 6,
    minZoom: 3
  });

  const mapRef = useRef();

  const handleViewportChange = useCallback((newViewport) => setViewport(newViewport),[]);

   /* SignalR */
   const [hubConnection, setHubConnection] = useState(null);
   const [zoom, setZoom] = useState(null);
     
   /* Load and prepare data */
   const { data, error } = useSwr(REACT_APP_DATA_URL + "/api/stations", fetcher);
   const stations = (data && !error) ? data : [];
   
   useEffect(() => {
       /* Create Hub Connection. */
       const createHubConnection = async () => {
 
           const hubConnect = new HubConnectionBuilder()
           .withUrl(REACT_APP_DATA_URL + "/livestations")
           .withAutomaticReconnect()
           .build();
           
           /* Set the initial SignalR Hub Connection. */
           setHubConnection(hubConnect);
           
       }
 
       createHubConnection();
   }, []);
   
   /* Websocket */
   useEffect(() => {
 
      
           if (hubConnection) {
                hubConnection
                   .start()
                   .then((result) => {
                       console.log("SignalR Connected!");
 
                       hubConnection.on("GetNewStationsAsync", (stations) => {
                           console.log("New Updated Data");
                           console.log(stations);
                           this.stations = stations;
                       });
                   })
                   .catch((e) => console.log("Connection failed: ", e));
           }
       
        
 
   }, [hubConnection]);

  /* Custom settings for ViewportChange */
  const handleGeocoderViewportChange = useCallback(
    (newViewport) => {
      const geocoderDefaultOverrides = {
        transitionDuration: 2000,
        pitch: 80,
        bearing: 0.7,
        transitionInterpolator: new FlyToInterpolator(),
      };

      return handleViewportChange({...newViewport, ...geocoderDefaultOverrides});
    },
    [handleViewportChange]
  );

  /* Live markers from the WebSocket */
  const [connection, setConnection] = useState(null);

  useEffect(() => {

    /* Gets markers from DB */
    props.dispatch(fetchMarkers());

    /* Gets WebSocket marker */
    const newConnection = new HubConnectionBuilder()
      .withUrl(REACT_APP_API_URL + "/livemarker", {
        headers: authHeader(),
      })
      .withAutomaticReconnect()
      .build();

    setConnection(newConnection);
  }, []);

  /* WebSocket connection */
  useEffect(() => {
    if (connection) {
      connection
        .start()
        .then((result) => {
          connection.on("GetNewMarker", (Marker) => {
            setMarkers((markers) => [...markers, Marker]);
          });
        })
        .catch((e) => console.log("Connection failed: ", e));
    }
  }, [connection]);

  /* Markers */
  const [markers, setMarkers] = useState([]);
  useEffect(() => {
    setMarkers(props.items);
  }, [props.items]);

  const handleController = () => {
    setController(true);
    setShowPopup(false);
    enableAddMarker(false);
  };

  const handleClick = ({ lngLat: [longitude, latitude] }) => {
    if (controllerSelect) {
      if (addMarker) {
        setShowPopup(true);
        setPopups([{ longitude, latitude }]);
      }
      enableAddMarker(true);
    }
  };

  const handleDelete = (obj) => () => {
    if (eraseMarker) {
      props.dispatch(deleteMarker(obj.marker.id, obj.index));
      enableEraseMarker(false);
    }
  };

  const handleCreate = (longitude, latitude, ico, message) => {
    const m = new MarkerEntity(longitude, latitude, "marker", JSON.stringify(ico));
    props.dispatch(createMarker(m));

    const n = new Notification(message.title, message.description, "Marker", Date.now);
    props.dispatch(createNotification(n));
    setShowPopup(false);
    enableAddMarker(false);
    setController(false);
  };

  /* Popup */
  const [popups, setPopups] = useState([]);
  const [controllerSelect, setController] = useState(false);
  const [showPopup, setShowPopup] = useState(false);
  const [addMarker, enableAddMarker] = useState(false);
  const [eraseMarker, enableEraseMarker] = useState(false);

  const _renderMarkerTools = () => {
    return (
      <div
        className="mapboxgl-ctrl-top-right"
        style={{ position: "absolute", top: 140 }}
      >
        <div className="mapboxgl-ctrl-group mapboxgl-ctrl">
          <button className="" title="Add marker" onClick={handleController}>
            <FontAwesomeIcon icon={faMapPin} />
          </button>
        </div>
        <div className="mapboxgl-ctrl-group mapboxgl-ctrl">
          <button
            className=""
            title="Delete marker"
            onClick={() => {
              enableEraseMarker(true);
              setShowPopup(false);
              setController(false);
            }}
          >
            <FontAwesomeIcon icon={faTrashAlt} />
          </button>
        </div>
      </div>
    );
  };

  const _renderMarkers = () => {
    
    return markers.map((m, i) => (
      <Marker {...m} key={i} offsetLeft={-20} offsetTop={-30}>
        <FontAwesomeIcon
          icon={JSON.parse(m.ico)}
          onClick={handleDelete({ marker: m, index: i })}
          style={{ fontSize: "20px", color: "#3a3a3a", cursor: "pointer" }}
        />{" "}
      </Marker>
    ));
  };

  const _renderMapTools = () => {
    return (
      <div>
        <div style={{ position: "absolute", right: 10, top: 10 }}>
          <NavigationControl />
        </div>
        <div style={{ position: "absolute", right: 10, top: 110 }}>
          <FullscreenControl />
        </div>

        <Geocoder
          mapRef={mapRef}
          onViewportChange={handleGeocoderViewportChange}
          mapboxApiAccessToken={REACT_APP_TOKEN}
          position="top-left"
        />
        <GeolocateControl
          style={{
            position: "absolute",
            right: 10,
            top: "29vh"
          }}
          positionOptions={{ enableHighAccuracy: true }}
          trackUserLocation={true}
          auto
        />
      </div>
    );
  };

  const _renderPopup = () => {
    return (
      showPopup &&
      popups.map((p, i) => (
        <Popup
          latitude={p.latitude}
          longitude={p.longitude}
          closeButton={false}
          closeOnClick={true}
          anchor="bottom"
          key={i}
        >
          <div className="p-2 ">
            <small>Pin and notify the others</small>
            <div className="d-flex justify-content-around mt-2 mb3">
              <button
                className="btn btn-info btn-sm mt-2 mr-2"
                onClick={() =>
                  handleCreate(p.longitude, p.latitude, faSmog, {
                    title: "Smog",
                    description:
                      "Danger for people with emphysema, bronchitis, and asthma.",
                  })
                }
              >
                <FontAwesomeIcon icon={faSmog} />
              </button>

              <button
                className="btn btn-dark btn-sm mt-2 mr-2"
                onClick={() =>
                  handleCreate(p.longitude, p.latitude, faCloudRain, {
                    title: "Heavy rainfall",
                    description:
                      "There is a risk of flooding and damaged infrastructure.",
                  })
                }
              >
                <FontAwesomeIcon icon={faCloudRain} />
              </button>
              <button
                className="btn btn-danger btn-sm mt-2"
                onClick={() =>
                  handleCreate(p.longitude, p.latitude, faFire, {
                    title: "Danger of Fire",
                    description:
                      "It might have toxic gases, thick black smoke, and lack of oxygen.",
                  })
                }
              >
                <FontAwesomeIcon icon={faFire} />
              </button>
            </div>
          </div>
        </Popup>
      ))
    );
  };

  const _changeColor = (aqi) => {
      
    if (aqi >= 0 && aqi <= 50) {
      return [162, 219, 96, 40];      
    }
    
    if (aqi >= 51 && aqi <= 100) {
      return [250, 213, 80, 40];      
    }

    if (aqi >= 101 && aqi <= 150) {
      return [253, 154, 87, 40];     
    }

    if (aqi >= 151 && aqi <= 200) {
      return [254, 104, 109, 40];      
    }

    if (aqi >= 201 && aqi <= 300) {
      return [155, 89, 117, 40];      
    }

    return [152, 86, 114, 40];  
  }

  // DeckGl Layers
  const scatterplotlayer = [
    new ScatterplotLayer({
        id: "scatterplot-layer",
        data: stations,
        getRadius: zoom * 100,
        radiusMaxPixels: 100,
        radiusMinPixels: 20,
        getFillColor: d => _changeColor(d.aqi),
        autoHighlight: true,
      })
  ];
  
  const textLayer = [
    new TextLayer({
      id: 'text-layer',
      data,
      pickable: true,
      getPosition: d => d.position,
      getText: d => `${d.aqi}`,
      getSize: zoom + 8,
      getAngle: 0,
      getTextAnchor: 'middle',
      getAlignmentBaseline: 'center'
    })
  ];

  return (
    <Container
      fluid
      style={{
        height: "85vh",
        width: "90vw",
        marginLeft: "7.5vw",
        marginTop: "3vh",
      }}
    >
      <MapGL
        ref={mapRef}
        {...viewport}
        width="100%"
        height="100%"
        onViewportChange={handleViewportChange}
        mapStyle="mapbox://styles/constantimi/ckisx2s921doh19sz2tyod230"
        mapboxApiAccessToken={REACT_APP_TOKEN}
        onClick={handleClick}
      >
        
        <DeckGL initialViewState={viewport}
          height={viewport.height}
          width={viewport.width}
          controller={true}
          layers={[scatterplotlayer, textLayer]}
          onViewStateChange={({ viewState }) => {
            console.log(`state: ${viewState.zoom}`);
            setZoom(viewState.zoom);
          }}
        />

        {_renderMarkers()}
        {_renderMarkerTools()}
        {_renderMapTools()}
        {_renderPopup() }
      </MapGL>
    </Container>
  );
};



function mapStateToProps(state) {
  const { items } = state.markers;
  return {
    items,
  };
}

export default connect(mapStateToProps)(Map);
