import axios from "axios";
import authHeader from "./auth.header";
const ***REMOVED*** REACT_APP_API_URL***REMOVED*** = process.env;

class NotificationService ***REMOVED***
  getAllNotifications = async () => ***REMOVED***
    return await axios.get(REACT_APP_API_URL + "/api/notifications/", ***REMOVED***
      headers: authHeader(),
   ***REMOVED***);
 ***REMOVED***;

  deleteNotification = async (id: number) => ***REMOVED***
    return axios.delete(REACT_APP_API_URL + "/api/notifications/" + id, ***REMOVED***
      headers: authHeader(),
   ***REMOVED***);
 ***REMOVED***;

  createNotification = async (notification: Notification) => ***REMOVED***
    return axios.post(REACT_APP_API_URL + "/api/notifications/", notification, ***REMOVED***
      headers: authHeader(),
   ***REMOVED***);
 ***REMOVED***
***REMOVED***

export default new NotificationService();
