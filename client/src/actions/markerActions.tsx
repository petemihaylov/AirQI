import ***REMOVED*** IMarker***REMOVED*** from "../entities/IMarker";
import MarkerService from "../services/marker.service";
import ***REMOVED*** CREATE_MARKER, FETCH_MARKERS***REMOVED*** from "./types";

export const fetchMarkers = () => (dispatch: any) => ***REMOVED***
  MarkerService.getAllMarkers().then(
    (response) => ***REMOVED***
      dispatch(***REMOVED***
        type: FETCH_MARKERS,
        payload: response.data,
     ***REMOVED***);
   ***REMOVED***,
    (error) => ***REMOVED***
      console.log(error);
   ***REMOVED***
  );
***REMOVED***;

export const createMarker = (marker: IMarker) => (dispatch: any) => ***REMOVED***
  return MarkerService.createMarker(marker).then((response) => ***REMOVED***
    dispatch(***REMOVED***
      type: CREATE_MARKER,
   ***REMOVED***);
 ***REMOVED***);
***REMOVED***;
