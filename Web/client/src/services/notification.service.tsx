import axios from "axios";
import authHeader from "./auth.header";
const { REACT_APP_API_URL } = process.env;

class NotificationService {
  getAllNotifications = async () => {
    return await axios.get(REACT_APP_API_URL + "/api/notifications/", {
      headers: authHeader(),
    });
  };

  deleteNotification = async (id: number) => {
    return axios.delete(REACT_APP_API_URL + "/api/notifications/" + id, {
      headers: authHeader(),
    });
  };

  createNotification = async (notification: Notification) => {
    return axios.post(REACT_APP_API_URL + "/api/notifications/", notification, {
      headers: authHeader(),
    });
  }
}

export default new NotificationService();
