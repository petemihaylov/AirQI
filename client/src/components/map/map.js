import "react-map-gl-geocoder/dist/mapbox-gl-geocoder.css";
import React, { useEffect, useState, useRef, useCallback } from "react";
import MapGL, { SVGOverlay, Marker } from "react-map-gl";
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
import MarkerEntity  from "../../entities/Marker";

//import DeckGL, { ScatterplotLayer } from "deck.gl";

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



  /* Stored markers from the DB */
  const [content, handleContent] = useState([]);

  /* Gets markers from DB */
  useEffect(() => {
    props.dispatch(fetchMarkers());
  }, [props]);

  useEffect(() => {
    handleContent(props.items);
  }, [props.items]);

  useEffect(() => {
    content.map((m) => handleMarker(m.longitude, m.latitude));
  }, [content]);




  /* Markers */
  const [markers, setMarkers] = useState([]);
  const handleMarker = (longitude, latitude) => {
    setMarkers((markers) => [...markers, { longitude, latitude }]);
    setShowPopup(false);
  };



  /* Popup */
  const [popups, setPopups] = useState([]);
  const [showPopup, setShowPopup] = useState(true);

  const handleClick = ({ lngLat: [longitude, latitude] }) => {
    setShowPopup(true);
    setPopups([{ longitude, latitude }]);
    // const m = new MarkerEntity(longitude, latitude);
    // props.dispatch(createMarker(m));
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
        mapboxApiAccessToken={REACT_APP_TOKEN}
        onClick={handleClick}
      >
        {/* <DeckGL viewState={viewport} layers={layers} /> */}

        <SVGOverlayLayer airData={data} radius={30} color={""} />
        {markers.map((m, i) => (
            <Marker {...m} key={i} offsetLeft={-20} offsetTop={-30}>
              <Pin style={{ width: "40px" }} />
            </Marker>
        ))}

        {showPopup &&
          popups.map((p, i) => (
            <Popup
              key={i}
              latitude={p.latitude}
              longitude={p.longitude}
              closeButton={false}
              closeOnClick={true}
              anchor="bottom"
            >
              <div className="p-2">
                <small>A warning will be created!</small>
                <button
                  className="btn btn-block btn-outline-dark btn-sm mt-2"
                  onClick={() => handleMarker(p.longitude, p.latitude)}
                >
                  Pin
                </button>
              </div>
            </Popup>
          ))}

        <div style={{ position: "absolute", right: 10, top: 10 }}>
          <NavigationControl />
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
