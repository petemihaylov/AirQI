import axios from "axios";
import { IMarker } from "../entities/interfaces/IMarker";
import authHeader from "./auth.header";
const { REACT_APP_MARKER_URL } = process.env;

class MarkerService {
  getAllMarkers = async () => {
    return await axios.get(REACT_APP_MARKER_URL + "/api/markers/", {
      headers:  {
        'Test-Header': 'test-value'
      },
    });
  };

  createMarker = async (marker: IMarker) => {
    return await axios.post(REACT_APP_MARKER_URL + "/api/markers/", marker);
  };

  deleteMarker = async (id: number) => {
    return axios.delete(REACT_APP_MARKER_URL + "/api/markers/" + id, {
      headers: authHeader(),
    });
  };
}

export default new MarkerService();
