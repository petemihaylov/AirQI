import ***REMOVED***
    ADD_PROFILE,
    UPDATE_PROFILE,
***REMOVED*** from "../actions/types";

const initialState = ***REMOVED*** user: null***REMOVED***;

export default function (state = initialState, action: any) ***REMOVED***
  const ***REMOVED*** type, payload***REMOVED*** = action;

  switch (type) ***REMOVED***
    case ADD_PROFILE:
      return ***REMOVED***
        ...state,
        user: payload.user,
     ***REMOVED***;
    case UPDATE_PROFILE:
      return ***REMOVED***
        ...state,
        user: payload.user,
     ***REMOVED***;
    default:
      return state;
 ***REMOVED***
***REMOVED***
