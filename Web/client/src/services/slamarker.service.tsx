import axios from "axios";
import SlaMarker from "../entities/SlaMarker";
import authHeader from "./auth.header";

const { REACT_APP_API_URL } = process.env;

class SlaMarkerService {
  createSlaMarker = async (sla: SlaMarker) => {
    return axios.post(REACT_APP_API_URL + "/api/slamarkers/", sla, {
      headers: authHeader(),
    });
  };

  getSlaMarkers = async () => {
    return axios.get(REACT_APP_API_URL + "/api/slamarkers/", {
      headers: authHeader(),
    });
  };
  deleteSlaMarker = async (id: number) => {
    return axios.delete(REACT_APP_API_URL + "/api/slamarkers/" + id, {
      headers: authHeader(),
    });
  };
}



export default new SlaMarkerService();