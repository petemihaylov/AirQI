import axios from "axios";
import ***REMOVED*** IMarker***REMOVED*** from "../entities/interfaces/IMarker";
import authHeader from "./auth.header";
const ***REMOVED*** REACT_APP_API_URL***REMOVED*** = process.env;

class MarkerService ***REMOVED***
  getAllMarkers = async () => ***REMOVED***
    return await axios.get(REACT_APP_API_URL + "/api/markers/", ***REMOVED***
      headers: authHeader(),
   ***REMOVED***);
 ***REMOVED***;

  createMarker = async (marker: IMarker) => ***REMOVED***
    return await axios.post(REACT_APP_API_URL + "/api/markers/", marker);
 ***REMOVED***;

  deleteMarker = async (id: number) => ***REMOVED***
    return axios.delete(REACT_APP_API_URL + "/api/markers/" + id, ***REMOVED***
      headers: authHeader(),
   ***REMOVED***);
 ***REMOVED***;
***REMOVED***

export default new MarkerService();
