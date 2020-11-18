import "react-map-gl-geocoder/dist/mapbox-gl-geocoder.css";
import React, { useEffect, useState, useRef, useCallback } from "react";
import MapGL, { SVGOverlay } from "react-map-gl";
import Geocoder from "react-map-gl-geocoder";
import { FlyToInterpolator, NavigationControl } from "react-map-gl";
import * as Locations from "./locations";
import Goo from "./goo";
import DeckGL, { ScatterplotLayer } from "deck.gl";

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
  }, []);

  // Custom settings for ViewportChange
  const handleGeocoderViewportChange = useCallback((newViewport) => {
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
  }, []);

  const layers = [
    new ScatterplotLayer({
      id: "scatterplot-layer",
      data: data,
      getRadius: 16 * 500,
      radiusMaxPixels: 18,
      getFillColor: [28, 218, 163],
      autoHighlight: true,
    }),
  ];
  return (
    <div style={{ height: "80vh" }}>
      <MapGL
        ref={mapRef}
        {...viewport}
        width="100%"
        height="100%"
        onViewportChange={handleViewportChange}
        mapboxApiAccessToken={REACT_APP_TOKEN}
      >
        {/* <DeckGL viewState={viewport} layers={layers} /> */}

        <SVGOverlayLayer airData={data} radius={50} />

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
    </div>
  );
};

function SVGOverlayLayer({ airData, radius }) {
  console.log(airData);
  const redraw = ({ project }) => {
    return (
      <g>
        <Goo>
          {airData.map((data) => {
            const [x, y] = project(data.position);
            return (
              <circle
                key={data.id}
                cx={x}
                cy={y}
                r={radius}
                fill={"#1cdaa3"}
                fillOpacity={0.4}
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
