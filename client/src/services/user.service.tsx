import axios from "axios";
import User from "../entities/User";
import authHeader from "./auth.header";

const { REACT_APP_API_URL } = process.env;

class UserService {
  getPublicContent = async () => {
    return axios.get(REACT_APP_API_URL + "/api/users/", {
      headers: authHeader(),
    });
  };

  getUserBoard = async () => {
    return axios.get(REACT_APP_API_URL + "/api/users/", {
      headers: authHeader(),
    });
  };

  getModeratorBoard = async () => {
    return axios.get(REACT_APP_API_URL + "/api/users/", {
      headers: authHeader(),
    });
  };

  getAdminBoard = async () => {
    return axios.get(REACT_APP_API_URL + "/api/users/", {
      headers: authHeader(),
    });
  };

  createUser = async (user: User) => {
    return axios.post(REACT_APP_API_URL + "/api/users/", user, {
      headers: authHeader(),
    });
  };

  deleteUser = async (id: number) => {
    return axios.delete(REACT_APP_API_URL + "/api/users/" + id, {
      headers: authHeader(),
    });
  };
}

export default new UserService();
