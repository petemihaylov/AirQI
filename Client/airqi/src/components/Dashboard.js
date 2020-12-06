import React, ***REMOVED*** useEffect, useState***REMOVED*** from 'react';
import fetchStationsData from '../actions/pull_stations';

export default function Dashboard() ***REMOVED***
    const [stations, setStationData] = useState([]);

    useEffect(() => ***REMOVED***
        fetchStationsData()
            .then(json => ***REMOVED***
                setStationData(json);
           ***REMOVED***)
            .catch(err => ***REMOVED***
                console.error(err.message);
           ***REMOVED***);
        
   ***REMOVED***);

    return (
        <div>
            ***REMOVED***stations***REMOVED***
        </div>
    );
***REMOVED*** 