import axios from "axios";

const JWT_URL = "http://localhost:5000/api/token/";
const API_URL = "http://localhost:8080/api/users/";

class AuthService {

  login(username, password) {
    // must be changed according to the TokenController in jwt-api
    return axios
      .post(JWT_URL, {
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

  logout() {
    localStorage.removeItem("user");
  }

  register(username, password, firstName, lastName, userRole) {
    return axios.post(API_URL, {
      username,
      password,
      firstName,
      lastName,
      userRole
    });
  }

  getCurrentUser() {
    return JSON.parse(localStorage.getItem("user"));
  }

}

export default new AuthService();
