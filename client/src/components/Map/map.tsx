import React, ***REMOVED*** useEffect, useRef***REMOVED*** from "react";
import "./css/style.css";

const ***REMOVED*** REACT_APP_MAP_KEY***REMOVED*** = process.env;

const Map = (props: any) => ***REMOVED***
  const googleMapRef: any = useRef();
  let googleMap: any;
  const placeName = "Amsterdam";

  useEffect(() => ***REMOVED***
    const googleMapScript = document.createElement("script");
    googleMapScript.src = `https://maps.googleapis.com/maps/api/js?key=$***REMOVED***REACT_APP_MAP_KEY***REMOVED***&libraries=places&map_ids=282d70afa0bb83db`;
    googleMapScript.async = true;

    window.document.body.appendChild(googleMapScript);
    googleMapScript.addEventListener("load", () => ***REMOVED***
      getLatLng();
   ***REMOVED***);
 ***REMOVED***, []);

  const createGoogleMap = (coordinates: any) => ***REMOVED***
    googleMap = new window.google.maps.Map(googleMapRef.current, ***REMOVED***
      zoom: 12,
      center: ***REMOVED***
        lat: coordinates.lat(),
        lng: coordinates.lng(),
     ***REMOVED***,
      disableDefaultUI: true,
   ***REMOVED***);
 ***REMOVED***;

  const getLatLng = () => ***REMOVED***
    let lat, lng, placeId;

    new window.google.maps.Geocoder().geocode(
      ***REMOVED*** address: `$***REMOVED***placeName***REMOVED***`***REMOVED***,

      function (results, status) ***REMOVED***
        if (status === window.google.maps.GeocoderStatus.OK) ***REMOVED***
          placeId = results[0].place_id;
          createGoogleMap(results[0].geometry.location);
          lat = results[0].geometry.location.lat();
          lng = results[0].geometry.location.lng();

          new window.google.maps.Marker(***REMOVED***
            position: ***REMOVED*** lat, lng***REMOVED***,
            map: googleMap,
            animation: window.google.maps.Animation.DROP,
            title: `$***REMOVED***placeName***REMOVED***`,
         ***REMOVED***);
       ***REMOVED*** else ***REMOVED***
          alert(
            "Geocode was not successful for the following reason: " + status
          );
       ***REMOVED***
     ***REMOVED***
    );
 ***REMOVED***;

  return (
    <div
      id="google-map"
      ref=***REMOVED***googleMapRef***REMOVED***
      style=***REMOVED******REMOVED*** width: "92vw", height: "83vh"***REMOVED******REMOVED***
    />
  );
***REMOVED***;

export default Map;
