import ***REMOVED***
  ADD_SLAMARKER,
  FETCH_SLAMARKERS,
  DELETE_SLAMARKER,
***REMOVED*** from "../actions/types";

const initialState = ***REMOVED*** items: []***REMOVED***;

export default function (state = initialState, action: any) ***REMOVED***
  const ***REMOVED*** type, payload***REMOVED*** = action;

  switch (type) ***REMOVED***
    case ADD_SLAMARKER:
      return ***REMOVED***
        ...state,
        items: [...state.items, payload],
     ***REMOVED***;
    case FETCH_SLAMARKERS:
      return ***REMOVED***
        ...state,
        items: payload,
     ***REMOVED***;
    case DELETE_SLAMARKER:
      return ***REMOVED***
        ...state,
        items: state.items.filter((item, index) => index !== action.payload),
     ***REMOVED***;
    default:
      return state;
 ***REMOVED***
***REMOVED***
