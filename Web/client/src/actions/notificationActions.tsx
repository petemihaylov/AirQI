import NotificationService from "../services/notification.service";
import { CREATE_NOTIFICATION, DELETE_NOTIFICATION, FETCH_NOTIFICATIONS } from "./types";

export const fetchNotifications = () => (dispatch: any) => {
  NotificationService.getAllNotifications().then(
    (response) => {
      dispatch({
        type: FETCH_NOTIFICATIONS,
        payload: response.data,
      });
    },
    (error) => {
      console.log(error);
    }
  );
};

export const createNotification = (notification: Notification) => (dispatch: any) => {
  NotificationService.createNotification(notification).then(
    (response) => {
      dispatch({
        type: CREATE_NOTIFICATION,
        payload:  response.data,
      });
    },
    (error) => {
      console.log(error);
    }
  );
}

export const deleteNotification = (id: number, index: number) => (dispatch: any) => {
  NotificationService.deleteNotification(id).then(
    (response) => {
      dispatch({
        type: DELETE_NOTIFICATION,
        payload: index,
      });
    },
    (error) => {
      console.log(error);
    }
  );
};
