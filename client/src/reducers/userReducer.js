import ***REMOVED*** FETCH_USERS, NEW_POST***REMOVED*** from "../actions/types";

const initialState = ***REMOVED***
  items: [],
  item: ***REMOVED******REMOVED***,
***REMOVED***;

const userReducer = (state = initialState, action) => ***REMOVED***
  switch (action.type) ***REMOVED***
    case FETCH_USERS:
      return ***REMOVED***
        ...state,
        items: action.data,
        item: ***REMOVED******REMOVED***,
     ***REMOVED***;

    default:
      return state;
 ***REMOVED***
***REMOVED***;

export default userReducer;
