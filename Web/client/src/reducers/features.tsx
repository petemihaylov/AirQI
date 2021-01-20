import ***REMOVED*** ADD_FEATURES***REMOVED*** from "../actions/types";

const initialState = ***REMOVED*** items: null***REMOVED***;

export default function (state = initialState, action: any) ***REMOVED***
  const ***REMOVED*** type, payload***REMOVED*** = action;

  switch (type) ***REMOVED***
    case ADD_FEATURES:
      return ***REMOVED***
        ...state,
        items: payload,
     ***REMOVED***;
    default:
      return state;
 ***REMOVED***
***REMOVED***
