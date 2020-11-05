import axios from "axios";
import authHeader from "./auth-header";

const { REACT_APP_API_URL } = process.env;

class UserService {
    getPublicContent() {
        return axios.get(REACT_APP_API_URL + "/users/");
    }

    getUserBoard() {
        return axios.get(REACT_APP_API_URL + "/users/", { headers: authHeader() });
    }

    getModeratorBoard() {
        return axios.get(REACT_APP_API_URL + "/users/", { headers: authHeader() });
    }

    getAdminBoard() {
        return axios.get(REACT_APP_API_URL + "/users/", { headers: authHeader() });
    }
}

export default new UserService();
