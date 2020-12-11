import React, ***REMOVED*** useEffect, useState***REMOVED*** from 'react';
import fetchStationsData from '../services/pull_stations';

export default function Dashboard() ***REMOVED***
    const [stations, setStationData] = useState([]);

    useEffect(() => ***REMOVED***
        fetchStationsData()
            .then(json => ***REMOVED***
                setStationData(json.data);
           ***REMOVED***)
            .catch(err => ***REMOVED***
                console.error(err.message);
           ***REMOVED***);
        
   ***REMOVED***);

    return (
        <div>
            ***REMOVED***stations && stations.map(function(station, index)***REMOVED*** 
                return (
                    <div>
                        ***REMOVED***index***REMOVED***. Aqicn saved ***REMOVED***station.location***REMOVED***
                    </div>
                )
           ***REMOVED***)***REMOVED***
        </div>
    );
***REMOVED*** 