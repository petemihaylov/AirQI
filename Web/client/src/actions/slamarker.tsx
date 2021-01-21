import ***REMOVED*** ADD_SLAMARKER, ADD_FEATURES, FETCH_SLAMARKERS***REMOVED*** from "./types";
import SlaMarkerService from "../services/slamarker.service";
import SlaMarker from "../entities/SlaMarker";

export const createSlaMarker = (sla: SlaMarker) => (dispatch: any) => ***REMOVED***
  return SlaMarkerService.createSlaMarker(sla).then((response) => ***REMOVED***
    console.log(response.data);
    dispatch(***REMOVED***
      type: ADD_SLAMARKER,
      payload: response.data,
   ***REMOVED***);
    return Promise.resolve();
 ***REMOVED***);
***REMOVED***;

export const fetchSlaMarkers = () => (dispatch: any) => ***REMOVED***
  SlaMarkerService.getSlaMarkers().then(
    (response) => ***REMOVED***
      dispatch(***REMOVED***
        type: FETCH_SLAMARKERS,
        payload: response.data,
     ***REMOVED***);
   ***REMOVED***,
    (error) => ***REMOVED***
      console.log(error);
   ***REMOVED***
  );
***REMOVED***;



export const addPolygon = (features: any) => (dispatch: any) => ***REMOVED***
  dispatch(***REMOVED***
    type: ADD_FEATURES,
    payload: features
 ***REMOVED***);
***REMOVED***