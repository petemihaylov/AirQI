import ***REMOVED*** ADD_SLAMARKER, ADD_FEATURES, FETCH_SLAMARKERS, DELETE_SLAMARKER***REMOVED*** from "./types";
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


export const deleteSlaMarker = (id: number, index: number) => (dispatch: any) => ***REMOVED***
  SlaMarkerService.deleteSlaMarker(id).then(
    (response) => ***REMOVED***
      dispatch(***REMOVED***
        type: DELETE_SLAMARKER,
        payload: index,
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