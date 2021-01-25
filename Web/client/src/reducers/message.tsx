import { SET_MESSAGE, CLEAR_MESSAGE } from "../actions/types";

const initialState = {message: null};

export default function (state = initialState, action: any) {
  const { type, payload } = action;

  switch (type) {
    case SET_MESSAGE:
      return {
        ...state,
        message: payload,
      };

    case CLEAR_MESSAGE:
      return { message: "" };

    default:
      return state;
  }
}
