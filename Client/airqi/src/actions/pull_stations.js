import axios from 'axios';

export default function fetchStationsData() {

    return axios.get('https://localhost:5001/api/stations/', {
        headers: {
          'Access-Control-Allow-Origin': 'https://localhost:5001',
          'Content-Type': 'application/json',
        }
    });
}