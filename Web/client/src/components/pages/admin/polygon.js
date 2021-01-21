import React, { useEffect, useState, useRef, useCallback } from "react";
import { Container } from "react-bootstrap";
import { addPolygon } from "../../../actions/slamarker";
import MapGL, { NavigationControl } from "react-map-gl";
import { Editor, DrawPolygonMode, EditingMode } from "react-map-gl-draw";
import { connect } from "react-redux";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { customFeatureStyle, customHandleStyle } from "./polygon-style";

import {
  faDrawPolygon,
  faSlidersH,
  faTrashAlt
} from "@fortawesome/free-solid-svg-icons";

const DEFAULT_VIEWPORT = {
  latitude: 52.3676,
  longitude: 4.9041,
  pitch: 60,
  bearing: 0.7,
  zoom: 11,
};

const Polygon = (props) => {
  const { REACT_APP_TOKEN } = process.env;
  const mapRef = useRef();

  const [viewport, setViewport] = useState(DEFAULT_VIEWPORT);
  const [modeHandler, setMode] = useState(null);
  const [features, setFeatures] = useState([]);
  const [deletePolygon, setDelete] = useState(false);

  const handleUpdate = (val) => {
    setFeatures(val.data);
  };

  useEffect(() => {
    props.dispatch(addPolygon(features));
  }, [features]);

  const hanldeSelect = (val) => {
    var arr = features;
    if (deletePolygon) {
      for (var i = 0; i < arr.length; i++) {
        if (i === val.selectedFeatureIndex) {
          arr.splice(i, 1);
        }
      }
      setFeatures(arr);
    }

    setDelete(false);
  };

  const handleViewportChange = useCallback(
    (newViewport) => setViewport(newViewport),
    []
  );

  const _renderToolbar = () => {
    return (
      <div>
        <div style={{ position: "absolute", right: 10, top: 10 }}>
          <NavigationControl />
        </div>
        <div
          className="mapboxgl-ctrl-group mapboxgl-ctrl"
          style={{ position: "absolute", left: 10, top: 10 }}
        >
          <button>
            <FontAwesomeIcon
              icon={faDrawPolygon}
              onClick={() => setMode(new DrawPolygonMode())}
            />
          </button>
        </div>
        <div
          className="mapboxgl-ctrl-group mapboxgl-ctrl"
          style={{ position: "absolute", left: 10, top: 50 }}
        >
          <button>
            <FontAwesomeIcon
              icon={faSlidersH}
              onClick={() => setMode(new EditingMode())}
            />
          </button>
        </div>
        <div
          className="mapboxgl-ctrl-group mapboxgl-ctrl"
          style={{ position: "absolute", left: 10, top: 90 }}
        >
          <button>
            <FontAwesomeIcon
              icon={faTrashAlt}
              onClick={() => {
                setMode(new EditingMode());
                setDelete(true);
              }}
            />
          </button>
        </div>
      </div>
    );
  };

  return (
    <Container
      style={{
        height: "56vh",
        marginTop: "1vh",
        padding: "0",
        width: "100%",
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
      >
        <Editor
          clickRadius={12}
          mode={modeHandler}
          featureStyle={customFeatureStyle}
          editHandleStyle={customHandleStyle}
          onUpdate={handleUpdate}
          onSelect={hanldeSelect}
          features={features}
        />
        {_renderToolbar()}
      </MapGL>
    </Container>
  );
};

function mapStateToProps(state) {
  const { features } = state.features;
  return {
    features,
  };
}

export default connect(mapStateToProps)(Polygon);
