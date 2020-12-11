import { DELETE_NOTIFICATION, FETCH_NOTIFICATIONS } from "../actions/types";

const initialState = { items: [] };

export default function (state = initialState, action: any) {
  const { type, payload } = action;

  switch (type) {
    case FETCH_NOTIFICATIONS:
      return {
        ...state,
        items: payload,
      };

    case DELETE_NOTIFICATION:
        return {
          ...state,
          items: state.items.filter((item, index) => index !== action.payload),
        };
    default:
      return state;
  }
}
