import {
  ADD_SLAMARKER,
  FETCH_SLAMARKERS,
  DELETE_SLAMARKER,
} from "../actions/types";

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
    case DELETE_SLAMARKER:
      return {
        ...state,
        items: state.items.filter((item, index) => index !== action.payload),
      };
    default:
      return state;
  }
}
