import ***REMOVED*** FETCH_USERS***REMOVED*** from "../actions/types";

const initialState = ***REMOVED*** items: []***REMOVED***;

export default function (state = initialState, action: any) ***REMOVED***
  const ***REMOVED*** type, payload***REMOVED*** = action;

  switch (type) ***REMOVED***
    case FETCH_USERS:
      return ***REMOVED***
        ...state,
        items: payload,
     ***REMOVED***;
    default:
      return state;
 ***REMOVED***
***REMOVED***
