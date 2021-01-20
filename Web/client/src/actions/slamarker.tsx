import ***REMOVED*** ADD_SLAMARKER, SET_MESSAGE, ADD_FEATURES***REMOVED*** from "./types";
import SlaMarkerService from "../services/slamarker.service";
import SlaMarker from "../entities/SlaMarker";

export const createSlaMarker = (sla: SlaMarker) => (dispatch: any) => ***REMOVED***
  return SlaMarkerService.createSlaMarker(sla).then((response) => ***REMOVED***
    dispatch(***REMOVED***
      type: ADD_SLAMARKER,
      payload: response.data,
   ***REMOVED***);

    dispatch(***REMOVED***
      type: SET_MESSAGE,
      payload: "The Sla was created successfully.",
   ***REMOVED***);

    return Promise.resolve();
 ***REMOVED***);
***REMOVED***;

export const addPolygon = (features: any) => (dispatch: any) => ***REMOVED***

  dispatch(***REMOVED***
    type: ADD_FEATURES,
    payload: features
 ***REMOVED***);

  dispatch(***REMOVED***
    type: SET_MESSAGE,
    payload: "The polygon features were added.",
 ***REMOVED***);

***REMOVED***