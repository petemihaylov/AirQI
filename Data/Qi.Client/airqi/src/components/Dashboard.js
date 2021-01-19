// https://react-bootstrap-table.github.io/react-bootstrap-table2/storybook/
import BootstrapTable from 'react-bootstrap-table-next';
import paginationFactory from 'react-bootstrap-table2-paginator';
import filterFactory, ***REMOVED*** textFilter***REMOVED*** from 'react-bootstrap-table2-filter';
import ToolkitProvider, ***REMOVED*** Search***REMOVED*** from 'react-bootstrap-table2-toolkit';

import ***REMOVED*** HubConnectionBuilder***REMOVED*** from "@microsoft/signalr";

import React, ***REMOVED*** useEffect, useState***REMOVED*** from 'react';
import ***REMOVED*** Container***REMOVED*** from 'reactstrap';
import useSwr from "swr";

// Data fetching method
const fetcher = (...args) => fetch(...args).then(response => response.json());

export default function Dashboard() ***REMOVED***

    const [hubConnection, setHubConnection] = useState(null);
    
    // Load and prepare data
    const ***REMOVED*** data, error***REMOVED*** = useSwr(process.env.REACT_APP_API_URL + "api/stations", fetcher);
    const stations = (data && !error) ? data : [];
    
    useEffect(() => ***REMOVED***
        // Create Hub Connection.
        const createHubConnection = async () => ***REMOVED***

            const hubConnect = new HubConnectionBuilder()
            .withUrl(process.env.REACT_APP_API_URL + "livestations")
            .withAutomaticReconnect()
            .build();
            
            // Set the initial SignalR Hub Connection.
            setHubConnection(hubConnect);
            
       ***REMOVED***

        createHubConnection();
   ***REMOVED***, []);
    
    // Websocket
    useEffect(() => ***REMOVED***

        const startHubConnection = async () => ***REMOVED***
            if (hubConnection) ***REMOVED***
                await hubConnection
                    .start()
                    .then((result) => ***REMOVED***
                        console.log("SignalR Connected!");

                        hubConnection.on("GetNewStationsAsync", (stations) => ***REMOVED***
                            console.log("New Updated Data");
                            console.log(stations);
                            this.stations = stations;
                       ***REMOVED***);
                   ***REMOVED***)
                    .catch((e) => console.log("Connection failed: ", e));
           ***REMOVED***
       ***REMOVED***
         
        startHubConnection();

   ***REMOVED***, [hubConnection]);


    // Render the information
    const ***REMOVED*** SearchBar***REMOVED*** = Search;

    const columns = [***REMOVED***
        dataField: 'id',
        text: '_id',
        sort: true
     ***REMOVED***, ***REMOVED***
        dataField: 'location',
        text: 'Name',
        sort: true
     ***REMOVED***, ***REMOVED***
        dataField: 'city',
        text: 'City',
        sort: true
     ***REMOVED***, ***REMOVED***
        dataField: 'country',
        text: 'Country',
        // filter: textFilter(),
        sort: true
     ***REMOVED***, ***REMOVED***
        dataField: 'aqi',
        text: 'Aqi',
        sort: true
   ***REMOVED***];
    
    return(
        <Container>
            <ToolkitProvider keyField="id" data=***REMOVED***stations***REMOVED*** columns=***REMOVED***columns***REMOVED*** search>
            ***REMOVED***
                props => (
                <div>
                    <h3>AirQi Stations Data </h3>
                    <SearchBar ***REMOVED*** ...props.searchProps***REMOVED*** />
                    <BootstrapTable ***REMOVED*** ...props.baseProps***REMOVED*** filter=***REMOVED***filterFactory()***REMOVED*** pagination=***REMOVED***paginationFactory()***REMOVED*** striped hover />
                </div>
                )
           ***REMOVED***
            </ToolkitProvider>
        </Container>
    );

***REMOVED*** 