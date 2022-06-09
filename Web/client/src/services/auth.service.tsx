import axios from "axios";
import User from "../entities/User";

const { REACT_APP_AUTH_URL, REACT_APP_USER_URL } = process.env;

export default class AuthService {
  static login = async (username: string, password: string) => {
    console.log(username + " " + password);
    return axios.post(REACT_APP_AUTH_URL + "/api/token" || "", {
        username,
        password,
      })
      .then((response) => {
        if (response.data.accessToken) {
          localStorage.setItem("user", JSON.stringify(response.data));
        }
        return response.data;
      });
  };

  static logout() {
    localStorage.removeItem("user");
  }

  static register = async (user: User) => {
    return await axios.post(REACT_APP_USER_URL + "/api/users/", user);
  };

  static getCurrentUser(): User {
    return JSON.parse(localStorage.getItem("user") || "{}");
  }
}
