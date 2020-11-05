import axios from "axios";

const { REACT_APP_JWT_URL, REACT_APP_API_URL } = process.env;

class AuthService {
  login(username, password) {
    console.log(process.env);
    // must be changed according to the TokenController in jwt-api
    return axios
      .post(REACT_APP_JWT_URL, {
        username,
        password,
      })
      .then((response) => {
        if (response.data.accessToken) {
          console.log(JSON.stringify(response.data));
          localStorage.setItem("user", JSON.stringify(response.data));
        }

        return response.data;
      })
      .catch((error) => {
        this.setState({ errorMessage: error.message });
        console.error("There was an error!", error);
      });
  }

  logout() {
    localStorage.removeItem("user");
  }

  register(username, password, firstName, lastName, userRole) {
    return axios.post(REACT_APP_API_URL, {
      username,
      password,
      firstName,
      lastName,
      userRole, 
    });
  }

  getCurrentUser() {
    return JSON.parse(localStorage.getItem("user"));
  }
}

export default new AuthService();
