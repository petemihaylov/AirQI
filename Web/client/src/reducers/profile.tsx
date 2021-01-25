import {
    ADD_PROFILE,
    UPDATE_PROFILE,
} from "../actions/types";

const initialState = { user: null};

export default function (state = initialState, action: any) {
  const { type, payload } = action;

  switch (type) {
    case ADD_PROFILE:
      return {
        ...state,
        user: payload.user,
      };
    case UPDATE_PROFILE:
      return {
        ...state,
        user: payload.user,
      };
    default:
      return state;
  }
}
