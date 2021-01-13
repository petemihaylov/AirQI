import "react-map-gl-geocoder/dist/mapbox-gl-geocoder.css";
import React, { useEffect, useState, useRef, useCallback } from "react";
import MapGL, { SVGOverlay, Marker, FullscreenControl } from "react-map-gl";
import Geocoder from "react-map-gl-geocoder";
import { FlyToInterpolator, NavigationControl, Popup } from "react-map-gl";
import * as Locations from "./locations";
import { Container } from "react-bootstrap";
import Goo from "./goo";
import "mapbox-gl/dist/mapbox-gl.css";
import { ReactComponent as Pin } from "../../assets/media/icons/pin-icon.svg";
import { connect } from "react-redux";
import { fetchMarkers, createMarker } from "../../actions/markerActions";
import { HubConnectionBuilder } from "@microsoft/signalr";
import authHeader from "../../services/auth.header";
import MarkerEntity from "../../entities/Marker";
import { faMapMarkerAlt, faFire, faSmog, faCloudRain } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

import DeckGL, { ScatterplotLayer } from "deck.gl";

const { REACT_APP_TOKEN } = process.env;
const { REACT_APP_API_URL } = process.env;

const Map = (props) => {
  const [viewport, setViewport] = useState({
    latitude: Locations.nyc.location.latitude,
    longitude: Locations.nyc.location.longitude,
    pitch: 60,
    bearing: 0.7,
    zoom: 11,
  });
  const mapRef = useRef();

  const handleViewportChange = useCallback(
    (newViewport) => setViewport(newViewport),
    []
  );

  const [data, setAirData] = useState([]);
  useEffect(() => {
    setAirData(Locations.data);
  }, []);

  /* Custom settings for ViewportChange */
  const handleGeocoderViewportChange = useCallback(
    (newViewport) => {
      const geocoderDefaultOverrides = {
        transitionDuration: 2000,
        pitch: 67,
        bearing: 0.7,
        transitionInterpolator: new FlyToInterpolator(),
      };

      return handleViewportChange({
        ...newViewport,
        ...geocoderDefaultOverrides,
      });
    },
    [handleViewportChange]
  );

  // Live markers from the WebSocket
  const [connection, setConnection] = useState(null);

  /* Gets WebSocket marker */
  useEffect(() => {
    const newConnection = new HubConnectionBuilder()
      .withUrl(REACT_APP_API_URL + "/livemarker", {
        headers: authHeader(),
      })
      .withAutomaticReconnect()
      .build();

    setConnection(newConnection);
  }, []);

  useEffect(() => {
    if (connection) {
      connection
        .start()
        .then((result) => {
          console.log("Connected!");

          connection.on("GetNewMarker", (Marker) => {
            handleMarker(Marker.longitude, Marker.latitude);
          });
        })
        .catch((e) => console.log("Connection failed: ", e));
    }
  }, [connection]);


  /* Gets markers from DB */
  useEffect(() => {
    props.dispatch(fetchMarkers());
  }, []);

  useEffect(() => {
    props.items.map((m) => handleMarker(m.longitude, m.latitude, m.id));
    console.log(props.items);
  }, [props.items]);


  /* Markers */
  const [markers, setMarkers] = useState([]);
  const handleMarker = (longitude, latitude, id) => {
    setMarkers((markers) => [...markers, { longitude, latitude, id }]);
  };

  /* Popup */
  const [popups, setPopups] = useState([]);
  const [controllerSelect, setController] = useState(false);
  const [showPopup, setShowPopup] = useState(false);
  const [feature, setFeature] = useState(false);
  
  const handleController = () => {
    setController(!controllerSelect);
    setShowPopup(false);
    setFeature(false);
  };

  const handleClick = ({ lngLat: [longitude, latitude] }) => {
    if(controllerSelect){

      if(feature){
        setShowPopup(true);
        setPopups([{ longitude, latitude }]);
      }
      setFeature(true);
    }
  };
  const handleDelete = () => {
      console.log( `Delete`);
  }
  const handleCreate = (longitude, latitude) => {
    const m = new MarkerEntity(longitude, latitude);
    props.dispatch(createMarker(m));

    //    handleMarker(longitude, latitude);
  };

  // Creating a marker tool
  const renderMarkerTool = () => {
    return (
      <div className="mapboxgl-ctrl-top-left mt-5">
        <div className="mapboxgl-ctrl-group mapboxgl-ctrl">
          <button className="" title="Marker" onClick={handleController}>
            <FontAwesomeIcon icon={faMapMarkerAlt} />
          </button>
        </div>
      </div>
    );
  };
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
        {/* <DeckGL viewState={viewport} layers={layers} /> */}

        <SVGOverlayLayer airData={data} radius={30} color={""} />
        {markers.map((m, i) => (
          <Marker {...m} key={i} offsetLeft={-20} offsetTop={-30}>
            <Pin
              onClick={() => console.log(markers)}
              style={{ width: "40px" }}
            />
          </Marker>
        ))}

        {showPopup &&
          popups.map((p, i) => (
            <Popup
              latitude={p.latitude}
              longitude={p.longitude}
              closeButton={false}
              closeOnClick={true}
              anchor="bottom"
              key={i}
            >
              <div className="p-2">
                <small>A warning will be created!</small>

                <div
                  style={{ height: "50px", overflowY: "auto" }}
                  className="mt-2 mb-2"
                >
                  <div className="d-flex justify-content-around">
                    <FontAwesomeIcon icon={faFire} /> Fire
                  </div>
                  <div className="d-flex justify-content-around">
                    <FontAwesomeIcon icon={faSmog} /> Smog
                  </div>
                  <div className="d-flex justify-content-around">
                    <FontAwesomeIcon icon={faCloudRain} />
                    Clouds
                  </div>
                  <div className="d-flex justify-content-around">
                    <FontAwesomeIcon icon={faFire} /> Fire
                  </div>
                  <div className="d-flex justify-content-around">
                    <FontAwesomeIcon icon={faSmog} /> Smog
                  </div>
                  <div className="d-flex justify-content-around">
                    <FontAwesomeIcon icon={faCloudRain} />
                    Clouds
                  </div>
                </div>

                <button
                  className="btn btn-block btn-outline-dark btn-sm mt-2"
                  onClick={() => handleCreate(p.longitude, p.latitude)}
                >
                  Pin
                </button>
              </div>
            </Popup>
          ))}

        {renderMarkerTool()}

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
      </MapGL>
    </Container>
  );

  // const layers = [
  //     new ScatterplotLayer({
  //       id: "scatterplot-layer",
  //       data: data,
  //       getRadius: 16 * 500,
  //       radiusMaxPixels: 18,
  //       getFillColor: [28, 218, 163],
  //       autoHighlight: true,
  //     }),
  //   ];
};

function SVGOverlayLayer({ airData, radius, color }) {
  const redraw = ({ project }) => {
    return (
      <g>
        <Goo>
          {airData.map((data, index) => {
            const [x, y] = project(data.position);
            if (index % 3 === 0) color = "#1daffe";
            else color = "#1cdaa3";

            return (
              <circle
                key={data.id}
                cx={x}
                cy={y}
                r={radius}
                fill={color}
                fillOpacity={0.4}
                onClick={() => {
                  alert(
                    "The area location: (" + x + " - " + y + ") was clicked."
                  );
                  return false;
                }}
              />
            );
          })}
        </Goo>
      </g>
    );
  };

  return <SVGOverlay redraw={redraw} />;
}

function mapStateToProps(state) {
  const { items } = state.markers;
  return {
    items,
  };
}

export default connect(mapStateToProps)(Map);
