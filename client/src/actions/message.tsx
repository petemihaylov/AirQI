import ***REMOVED*** SET_MESSAGE, CLEAR_MESSAGE***REMOVED*** from "./types";

export const setMessage = (message: string) => (***REMOVED***
  type: SET_MESSAGE,
  payload: message,
***REMOVED***);

export const clearMessage = () => (***REMOVED***
  type: CLEAR_MESSAGE,
***REMOVED***);
