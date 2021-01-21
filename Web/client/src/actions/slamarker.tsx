import { ADD_SLAMARKER, ADD_FEATURES, FETCH_SLAMARKERS } from "./types";
import SlaMarkerService from "../services/slamarker.service";
import SlaMarker from "../entities/SlaMarker";

export const createSlaMarker = (sla: SlaMarker) => (dispatch: any) => {
  return SlaMarkerService.createSlaMarker(sla).then((response) => {
    console.log(response.data);
    dispatch({
      type: ADD_SLAMARKER,
      payload: response.data,
    });
    return Promise.resolve();
  });
};

export const fetchSlaMarkers = () => (dispatch: any) => {
  SlaMarkerService.getSlaMarkers().then(
    (response) => {
      dispatch({
        type: FETCH_SLAMARKERS,
        payload: response.data,
      });
    },
    (error) => {
      console.log(error);
    }
  );
};



export const addPolygon = (features: any) => (dispatch: any) => {
  dispatch({
    type: ADD_FEATURES,
    payload: features
  });
}