import ***REMOVED*** HubConnectionBuilder***REMOVED*** from "@microsoft/signalr";
import React, ***REMOVED*** useEffect, useState***REMOVED*** from 'react';
import fetchStationsData from '../services/pull_stations';

const ***REMOVED*** REACT_APP_API_URL***REMOVED*** = process.env;
export default function Dashboard() ***REMOVED***

    const [connection, setConnection] = useState(null);
    const [stations, setStationData] = useState([]);

    useEffect(() => ***REMOVED***        
        const newConnection = new HubConnectionBuilder()
            .withUrl(REACT_APP_API_URL + "livestations")
            .withAutomaticReconnect()
            .build();
      
        setConnection(newConnection);
   ***REMOVED***, []);

    useEffect(() => ***REMOVED***
        fetchStationsData()
        .then(json => ***REMOVED***
            setStationData(json.data);
       ***REMOVED***)
        .catch(err => ***REMOVED***
            console.error(err.message);
       ***REMOVED***);
   ***REMOVED***, []);

    useEffect(() => ***REMOVED***
        if (connection) ***REMOVED***
            connection
            .start()
            .then((result) => ***REMOVED***
                console.log("Connected!");

                connection.on("GetNewStations", (station) => ***REMOVED***
                setStationData([station]);
               ***REMOVED***);
           ***REMOVED***)
            .catch((e) => console.log("Connection failed: ", e));
       ***REMOVED***
   ***REMOVED***, [connection]);

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