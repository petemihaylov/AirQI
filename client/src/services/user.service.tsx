import axios from "axios";
import User from "../entities/User";
import authHeader from "./auth.header";

const { REACT_APP_API_URL } = process.env;

class UserService {
  getPublicContent() {
    return axios.get(REACT_APP_API_URL + "/api/users/", {
      headers: authHeader(),
    });
  }

  getUserBoard() {
    return axios.get(REACT_APP_API_URL + "/api/users/", {
      headers: authHeader(),
    });
  }

  getModeratorBoard() {
    return axios.get(REACT_APP_API_URL + "/api/users/", {
      headers: authHeader(),
    });
  }

  getAdminBoard() {
    return axios.get(REACT_APP_API_URL + "/api/users/", {
      headers: authHeader(),
    });
  }

  createUser(user: User) {
    return axios.post(REACT_APP_API_URL + "/api/users/", user, {
      headers: authHeader(),
    });
  }

  deleteUser(id: number) {
    return axios.delete(REACT_APP_API_URL + "/api/users/" + id, {
      headers: authHeader(),
    });
  }
}

export default new UserService();
