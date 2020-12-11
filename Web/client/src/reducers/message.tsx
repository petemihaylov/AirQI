import ***REMOVED*** SET_MESSAGE, CLEAR_MESSAGE***REMOVED*** from "../actions/types";

const initialState = ***REMOVED******REMOVED***;

export default function (state = initialState, action: any) ***REMOVED***
  const ***REMOVED*** type, payload***REMOVED*** = action;

  switch (type) ***REMOVED***
    case SET_MESSAGE:
      return ***REMOVED*** message: payload***REMOVED***;

    case CLEAR_MESSAGE:
      return ***REMOVED*** message: ""***REMOVED***;

    default:
      return state;
 ***REMOVED***
***REMOVED***
