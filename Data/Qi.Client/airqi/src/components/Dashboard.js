import ***REMOVED*** HubConnectionBuilder***REMOVED*** from "@microsoft/signalr";
import React, ***REMOVED*** useEffect, useState***REMOVED*** from 'react';
import fetchStationsData from '../services/pull_stations';
import Layout from "./Layout";
import Loading from "./Loading";

const ***REMOVED*** REACT_APP_API_URL***REMOVED*** = process.env;
export default function Dashboard() ***REMOVED***

    const [hubConnection, setHubConnection] = useState(null);
    const [stations, setStationData] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => ***REMOVED***
        // Fetching data
        const setStationsData = async () => ***REMOVED***
            fetchStationsData()
                .then(json => ***REMOVED***
                    setLoading(false);
                    console.log(json.data);
                    setStationData(json.data);
               ***REMOVED***)
                .catch(err => ***REMOVED***
                    console.error(err.message);
               ***REMOVED***);
       ***REMOVED***

        setStationsData();
   ***REMOVED***, []);

    useEffect(() => ***REMOVED***

        // Create Hub Connection.
        const createHubConnection = async () => ***REMOVED***

            const hubConnect = new HubConnectionBuilder()
            .withUrl(REACT_APP_API_URL + "livestations")
            .withAutomaticReconnect()
            .build();
            
            // Set the initial SignalR Hub Connection.
            setHubConnection(hubConnect);
            
       ***REMOVED***

        createHubConnection();
   ***REMOVED***, []);

    useEffect(() => ***REMOVED***

        const startHubConnection = async () => ***REMOVED***
            if (hubConnection) ***REMOVED***
                await hubConnection
                    .start()
                    .then((result) => ***REMOVED***
                        console.log("Hub Connected!");

                        hubConnection.on("GetNewStations", (stations) => ***REMOVED***
                            console.log(stations);
                            setStationData([stations]);
                       ***REMOVED***);
                   ***REMOVED***)
                    .catch((e) => console.log("Connection failed: ", e));
           ***REMOVED***
       ***REMOVED***
         
        startHubConnection();

   ***REMOVED***, [hubConnection]);


    // Render the information
    return loading ? <Loading /> : <Layout collection=***REMOVED***stations***REMOVED*** />;

***REMOVED*** 