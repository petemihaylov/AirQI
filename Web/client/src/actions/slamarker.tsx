import { ADD_SLAMARKER, SET_MESSAGE, ADD_FEATURES } from "./types";
import SlaMarkerService from "../services/slamarker.service";
import SlaMarker from "../entities/SlaMarker";

export const createSlaMarker = (sla: SlaMarker) => (dispatch: any) => {
  return SlaMarkerService.createSlaMarker(sla).then((response) => {
    dispatch({
      type: ADD_SLAMARKER,
      payload: response.data,
    });

    dispatch({
      type: SET_MESSAGE,
      payload: "The Sla was created successfully.",
    });

    return Promise.resolve();
  });
};

export const addPolygon = (features: any) => (dispatch: any) => {

  dispatch({
    type: ADD_FEATURES,
    payload: features
  });

  dispatch({
    type: SET_MESSAGE,
    payload: "The polygon features were added.",
  });

}