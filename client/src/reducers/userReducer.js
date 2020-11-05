import { FETCH_USERS, NEW_POST } from "../actions/types";

const initialState = {
  items: [],
  item: {},
};

const userReducer = (state = initialState, action) => {
  switch (action.type) {
    case FETCH_USERS:
      return {
        ...state,
        items: action.data,
        item: {},
      };

    default:
      return state;
  }
};

export default userReducer;
