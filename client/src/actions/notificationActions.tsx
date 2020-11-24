import NotificationService from "../services/notification.service";
import ***REMOVED*** DELETE_NOTIFICATION, FETCH_NOTIFICATIONS***REMOVED*** from "./types";

export const fetchNotifications = () => (dispatch: any) => ***REMOVED***
  NotificationService.getAllNotifications().then(
    (response) => ***REMOVED***
      dispatch(***REMOVED***
        type: FETCH_NOTIFICATIONS,
        payload: response.data,
     ***REMOVED***);
   ***REMOVED***,
    (error) => ***REMOVED***
      console.log(error);
   ***REMOVED***
  );
***REMOVED***;

export const deleteNotification = (id: number, index: number) => (dispatch: any) => ***REMOVED***
  NotificationService.deleteNotification(id).then(
    (response) => ***REMOVED***
      dispatch(***REMOVED***
        type: DELETE_NOTIFICATION,
        payload: index,
     ***REMOVED***);
   ***REMOVED***,
    (error) => ***REMOVED***
      console.log(error);
   ***REMOVED***
  );
***REMOVED***;
