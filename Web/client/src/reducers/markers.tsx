import ***REMOVED*** CREATE_MARKER, FETCH_MARKERS***REMOVED*** from "../actions/types";

const initialState = ***REMOVED*** items: []***REMOVED***;

export default function (state = initialState, action: any) ***REMOVED***
  const ***REMOVED*** type, payload***REMOVED*** = action;

  switch (type) ***REMOVED***
    case FETCH_MARKERS:
      return ***REMOVED***
        ...state,
        items: payload,
     ***REMOVED***;
    case CREATE_MARKER:
      return ***REMOVED***
        ...state,
     ***REMOVED***;
    default:
      return state;
 ***REMOVED***
***REMOVED***
