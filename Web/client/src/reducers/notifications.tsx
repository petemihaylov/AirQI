import ***REMOVED*** DELETE_NOTIFICATION, FETCH_NOTIFICATIONS, CREATE_NOTIFICATION***REMOVED*** from "../actions/types";

const initialState = ***REMOVED*** items: []***REMOVED***;

export default function (state = initialState, action: any) ***REMOVED***
  const ***REMOVED*** type, payload***REMOVED*** = action;

  switch (type) ***REMOVED***
    case FETCH_NOTIFICATIONS:
      return ***REMOVED***
        ...state,
        items: payload,
     ***REMOVED***;

    case DELETE_NOTIFICATION:
        return ***REMOVED***
          ...state,
          items: state.items.filter((item, index) => index !== action.payload),
       ***REMOVED***;
    case CREATE_NOTIFICATION:
      return ***REMOVED***
        ...state,
        items: [...state.items, payload],
     ***REMOVED***;
    default:
      return state;
 ***REMOVED***
***REMOVED***
