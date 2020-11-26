import { IMarker } from "../entities/IMarker";
import MarkerService from "../services/marker.service";
import { CREATE_MARKER, FETCH_MARKERS } from "./types";

export const fetchMarkers = () => (dispatch: any) => {
  MarkerService.getAllMarkers().then(
    (response) => {
      dispatch({
        type: FETCH_MARKERS,
        payload: response.data,
      });
    },
    (error) => {
      console.log(error);
    }
  );
};

export const createMarker = (marker: IMarker) => (dispatch: any) => {
  return MarkerService.createMarker(marker).then((response) => {
    dispatch({
      type: CREATE_MARKER,
    });
  });
};
