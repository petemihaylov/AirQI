import React, { useEffect, useRef } from "react";
import "./css/style.css";

const { REACT_APP_MAP_KEY } = process.env;

const Map = (props: any) => {
  const googleMapRef: any = useRef();
  let googleMap: any;
  const placeName = "Amsterdam";

  useEffect(() => {
    const googleMapScript = document.createElement("script");
    googleMapScript.src = `https://maps.googleapis.com/maps/api/js?key=${REACT_APP_MAP_KEY}&libraries=places&map_ids=282d70afa0bb83db`;
    googleMapScript.async = true;

    window.document.body.appendChild(googleMapScript);
    googleMapScript.addEventListener("load", () => {
      getLatLng();
    });
  }, []);

  const createGoogleMap = (coordinates: any) => {
    googleMap = new window.google.maps.Map(googleMapRef.current, {
      zoom: 12,
      center: {
        lat: coordinates.lat(),
        lng: coordinates.lng(),
      },
      disableDefaultUI: true,
    });
  };

  const getLatLng = () => {
    let lat, lng, placeId;

    new window.google.maps.Geocoder().geocode(
      { address: `${placeName}` },

      function (results, status) {
        if (status === window.google.maps.GeocoderStatus.OK) {
          placeId = results[0].place_id;
          createGoogleMap(results[0].geometry.location);
          lat = results[0].geometry.location.lat();
          lng = results[0].geometry.location.lng();

          new window.google.maps.Marker({
            position: { lat, lng },
            map: googleMap,
            animation: window.google.maps.Animation.DROP,
            title: `${placeName}`,
          });
        } else {
          alert(
            "Geocode was not successful for the following reason: " + status
          );
        }
      }
    );
  };

  return (
    <div
      id="google-map"
      ref={googleMapRef}
      style={{ width: "92vw", height: "83vh" }}
    />
  );
};

export default Map;
