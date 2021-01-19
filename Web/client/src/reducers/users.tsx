import ***REMOVED*** FETCH_USERS, DELETE_USER, CREATE_USER, UPDATE_USER***REMOVED*** from "../actions/types";

const initialState = ***REMOVED*** items: []***REMOVED***;

export default function (state = initialState, action: any) ***REMOVED***
  const ***REMOVED*** type, payload***REMOVED*** = action;

  switch (type) ***REMOVED***
    case FETCH_USERS:
      return ***REMOVED***
        ...state,
        items: payload,
     ***REMOVED***;
    case DELETE_USER:
      return ***REMOVED***
        ...state,
        items: state.items.filter((item, index) => index !== action.payload)
     ***REMOVED***;
    case CREATE_USER:
      return ***REMOVED***
        ...state,
        items: [...state.items, payload]
     ***REMOVED***;
    case UPDATE_USER:
      return ***REMOVED***
        ...state,
        user: payload.user,
     ***REMOVED***;
    default:
      return state;
 ***REMOVED***
***REMOVED***
