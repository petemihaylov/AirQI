import axios from "axios";

const JWT_URL = "http://localhost:5000/api/token/";

// const JWT_URL = "http://jwt-api.westeurope.azurecontainer.io/api/token/";

const API_URL = "http://apibase.westeurope.azurecontainer.io/api/users/";


class AuthService {

  login(username, password) {
    // must be changed according to the TokenController in jwt-api
    return axios
      .post(JWT_URL, {
        username,
        password,
      }).then((response) => {

        if (response.data.accessToken) {
          console.log(JSON.stringify(response.data));
          localStorage.setItem("user", JSON.stringify(response.data));
        }

        return response.data;
      })
      .catch(error => {
            this.setState({ errorMessage: error.message });
            console.error('There was an error!', error);
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
