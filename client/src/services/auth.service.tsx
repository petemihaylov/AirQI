import axios from "axios";
import User from "../entities/User";

const { REACT_APP_JWT_URL, REACT_APP_API_URL } = process.env;

export default class AuthService {
  static login(username: string, password: string) {
    return axios
      .post(REACT_APP_JWT_URL || "", {
        username,
        password,
      })
      .then((response) => {
        if (response.data.accessToken) {
          localStorage.setItem("user", JSON.stringify(response.data));
        }

        return response.data;
      });
  }

  static logout() {
    localStorage.removeItem("user");
  }

  static register(user: User) {
    return axios.post(REACT_APP_API_URL + "users/", user);
  }

  static getCurrentUser(): User {
    return JSON.parse(localStorage.getItem("user") || "{}");
  }
}
