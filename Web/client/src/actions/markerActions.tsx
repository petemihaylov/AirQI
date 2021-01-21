import ***REMOVED*** IMarker***REMOVED*** from "../entities/interfaces/IMarker";
import MarkerService from "../services/marker.service";
import ***REMOVED*** CREATE_MARKER, DELETE_MARKER, FETCH_MARKERS***REMOVED*** from "./types";

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
  return MarkerService.createMarker(marker)
    .then(
      (response) => ***REMOVED***
        dispatch(***REMOVED***
          type: CREATE_MARKER,
          payload: response.data,
       ***REMOVED***);
     ***REMOVED***,
      (error) => ***REMOVED***
        return Promise.reject();
     ***REMOVED***
    )
    .catch(() => ***REMOVED***
      return Promise.reject();
   ***REMOVED***);
***REMOVED***;

export const deleteMarker = (id: number, index: number) => (dispatch: any) => ***REMOVED***
  MarkerService.deleteMarker(id).then(
    (response) => ***REMOVED***
      dispatch(***REMOVED***
        type: DELETE_MARKER,
        payload: index,
     ***REMOVED***);
   ***REMOVED***,
    (error) => ***REMOVED***
      console.log(error);
   ***REMOVED***
  );
***REMOVED***;
