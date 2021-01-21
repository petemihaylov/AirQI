import axios from "axios";
import SlaMarker from "../entities/SlaMarker";
import authHeader from "./auth.header";

const ***REMOVED*** REACT_APP_API_URL***REMOVED*** = process.env;

class SlaMarkerService ***REMOVED***
  createSlaMarker = async (sla: SlaMarker) => ***REMOVED***
     return axios.post(REACT_APP_API_URL + "/api/slamarkers/", sla, ***REMOVED***
       headers: authHeader(),
    ***REMOVED***);
 ***REMOVED***;

  getSlaMarkers = async () => ***REMOVED***
    return axios.get(REACT_APP_API_URL + "/api/slamarkers/", ***REMOVED***
      headers: authHeader(),
   ***REMOVED***);
 ***REMOVED***;
***REMOVED***



export default new SlaMarkerService();