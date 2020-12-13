import axios from 'axios';

const ***REMOVED*** REACT_APP_API_URL***REMOVED*** = process.env;

export default async function fetchStationsData() ***REMOVED***
    return await axios.get(REACT_APP_API_URL + 'api/stations/', ***REMOVED***
        headers: ***REMOVED***
          'Content-Type': 'application/json',
       ***REMOVED***
   ***REMOVED***);
***REMOVED***