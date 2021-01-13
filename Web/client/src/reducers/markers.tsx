import ***REMOVED*** CREATE_MARKER, FETCH_MARKERS, DELETE_MARKER***REMOVED*** from "../actions/types";

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
        items: [...state.items, payload],
     ***REMOVED***;
    case DELETE_MARKER:
      return ***REMOVED***
        ...state,
        items: state.items.filter((item, index) => index !== action.payload),
     ***REMOVED***;
    default:
      return state;
 ***REMOVED***
***REMOVED***
