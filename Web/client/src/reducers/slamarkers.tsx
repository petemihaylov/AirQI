import { ADD_SLAMARKER, FETCH_SLAMARKERS } from "../actions/types";

const initialState = { items: [] };

export default function (state = initialState, action: any) {
  const { type, payload } = action;

  switch (type) {
    case ADD_SLAMARKER:
      return {
        ...state,
        items: [...state.items, payload],
      };
    case FETCH_SLAMARKERS:
      return {
        ...state,
        items: payload,
      };
    default:
      return state;
  }
}
