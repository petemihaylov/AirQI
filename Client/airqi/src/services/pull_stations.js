import axios from 'axios';

const { REACT_APP_API_URL } = process.env;

export default function fetchStationsData() {
    
    return axios.get(REACT_APP_API_URL + 'api/stations/', {
        headers: {
          'Content-Type': 'application/json',
        }
    });
}