import { IMarker } from "../entities/interfaces/IMarker";
import MarkerService from "../services/marker.service";
import { CREATE_MARKER, DELETE_MARKER, FETCH_MARKERS } from "./types";

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
  return MarkerService.createMarker(marker)
    .then((response) => {
      dispatch({
        type: CREATE_MARKER,
        payload: response.data,
      });
    })
    .catch(() => {
      return Promise.reject();
    });
};

export const deleteMarker = (id: number, index: number) => (dispatch: any) => {
  MarkerService.deleteMarker(id).then(
    (response) => {
      dispatch({
        type: DELETE_MARKER,
        payload: index,
      });
    },
    (error) => {
      console.log(error);
    }
  );
};
