import { CREATE_MARKER, FETCH_MARKERS } from "../actions/types";

const initialState = { items: [] };

export default function (state = initialState, action: any) {
  const { type, payload } = action;

  switch (type) {
    case FETCH_MARKERS:
      return {
        ...state,
        items: payload,
      };
    case CREATE_MARKER:
      return {
        ...state,
      };
    default:
      return state;
  }
}
