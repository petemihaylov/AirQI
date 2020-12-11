import axios from "axios";
import { IMarker } from "../entities/IMarker";
import authHeader from "./auth.header";
const { REACT_APP_API_URL } = process.env;

class MarkerService {
  getAllMarkers = async () => {
    return await axios.get(REACT_APP_API_URL + "/api/markers/", {
      headers: authHeader(),
    });
  };

  createMarker = async(marker: IMarker) =>{
      return await axios.post(REACT_APP_API_URL + "/api/markers/", marker);
  }
}

export default new MarkerService();
