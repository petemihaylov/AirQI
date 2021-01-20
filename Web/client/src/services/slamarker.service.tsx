import axios from "axios";
import SlaMarker from "../entities/SlaMarker";
import authHeader from "./auth.header";

const { REACT_APP_API_URL } = process.env;

class SlaMarkerService {
  createSlaMarker = async (sla: SlaMarker) => {
     return axios.post(REACT_APP_API_URL + "/api/salmarkers/", sla, {
       headers: authHeader(),
     });
  };
}



export default new SlaMarkerService();