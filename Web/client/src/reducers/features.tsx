import { ADD_FEATURES } from "../actions/types";

const initialState = { items: null };

export default function (state = initialState, action: any) {
  const { type, payload } = action;

  switch (type) {
    case ADD_FEATURES:
      return {
        ...state,
        items: payload,
      };
    default:
      return state;
  }
}
