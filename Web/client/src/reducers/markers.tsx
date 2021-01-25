import { CREATE_MARKER, FETCH_MARKERS, DELETE_MARKER } from "../actions/types";

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
        items: [...state.items, payload],
      };
    case DELETE_MARKER:
      return {
        ...state,
        items: state.items.filter((item, index) => index !== action.payload),
      };
    default:
      return state;
  }
}
