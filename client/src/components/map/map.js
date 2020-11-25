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
//import DeckGL, { ScatterplotLayer } from "deck.gl";

const { REACT_APP_TOKEN } = process.env;

const Map = () => {
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
    console.log(Locations.data);
  }, []);

  // Custom settings for ViewportChange
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

  const [markers, setMarkers] = React.useState([]);
  const handleClick = ({ lngLat: [longitude, latitude] }) =>
    setMarkers((markers) => [...markers, { longitude, latitude }]);

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

        <SVGOverlayLayer airData={data} radius={30} color={"#1cdaa3"} />
        {markers.map((m, i) => (
          <div>
            <Marker {...m} key={i} offsetLeft={-20} offsetTop={-30}>
              <Pin style={{ width: "40px" }} />
            </Marker>
            <Popup
              latitude={m.latitude}
              longitude={m.longitude}
              closeButton={true}
              closeOnClick={true}
              onClose={() => this.setState({ showPopup: false })}
              anchor="bottom"
            >
              <div>You are here</div>
            </Popup>
          </div>
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
            if ((index % 3) === 0) color = "#1daffe";
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

export default Map;
