import axios from 'axios';

export default function fetchStationsData() {

    return axios.get('https://localhost:5001/api/stations/', {
        method: 'GET',
        mode: 'CORS'
    });
}