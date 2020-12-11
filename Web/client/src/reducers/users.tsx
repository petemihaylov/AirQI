import { FETCH_USERS, DELETE_USER } from "../actions/types";

const initialState = { items: [] };

export default function (state = initialState, action: any) {
  const { type, payload } = action;

  switch (type) {
    case FETCH_USERS:
      return {
        ...state,
        items: payload,
      };
    case DELETE_USER:
      return {
        ...state,
        items: state.items.filter((item, index) => index !== action.payload)
      };
    default:
      return state;
  }
}
