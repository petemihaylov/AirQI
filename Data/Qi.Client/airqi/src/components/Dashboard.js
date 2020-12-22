// https://react-bootstrap-table.github.io/react-bootstrap-table2/storybook/
import BootstrapTable from 'react-bootstrap-table-next';
import paginationFactory from 'react-bootstrap-table2-paginator';
import filterFactory, { textFilter } from 'react-bootstrap-table2-filter';
import ToolkitProvider, { Search } from 'react-bootstrap-table2-toolkit';
//
import { HubConnectionBuilder } from "@microsoft/signalr";

import React, { useEffect, useState } from 'react';
import { Container } from 'reactstrap';
import useSwr from "swr";

// Data fetching method
const fetcher = (...args) => fetch(...args).then(response => response.json());

export default function Dashboard() {

    const [hubConnection, setHubConnection] = useState(null);
    
    // Load and prepare data
    const { data, error } = useSwr(process.env.REACT_APP_API_URL + "api/stations", fetcher);
    const stations = (data && !error) ? data : [];
    
    useEffect(() => {
        // Create Hub Connection.
        const createHubConnection = async () => {

            const hubConnect = new HubConnectionBuilder()
            .withUrl(process.env.REACT_APP_API_URL + "livestations")
            .withAutomaticReconnect()
            .build();
            
            // Set the initial SignalR Hub Connection.
            setHubConnection(hubConnect);
            
        }

        createHubConnection();
    }, []);
    
    // Websocket
    useEffect(() => {

        const startHubConnection = async () => {
            if (hubConnection) {
                await hubConnection
                    .start()
                    .then((result) => {
                        console.log("SignalR Connected!");

                        hubConnection.on("GetNewStationsAsync", (stations) => {
                            console.log("New Updated Data");
                            console.log(stations);
                            this.stations = stations;
                        });
                    })
                    .catch((e) => console.log("Connection failed: ", e));
            }
        }
         
        startHubConnection();

    }, [hubConnection]);


    // Render the information
    const { SearchBar } = Search;

    const columns = [{
        dataField: 'id',
        text: '_id',
        sort: true
      }, {
        dataField: 'location',
        text: 'Name',
        sort: true
      }, {
        dataField: 'city',
        text: 'City',
        sort: true
      }, {
        dataField: 'country',
        text: 'Country',
        // filter: textFilter(),
        sort: true
      }, {
        dataField: 'aqi',
        text: 'Aqi',
        sort: true
    }];
    
    return(
        <Container>
            <ToolkitProvider keyField="id" data={stations} columns={columns} search>
            {
                props => (
                <div>
                    <h3>AirQi Stations Data </h3>
                    <SearchBar { ...props.searchProps } />
                    <BootstrapTable { ...props.baseProps } filter={filterFactory()} pagination={paginationFactory()} striped hover />
                </div>
                )
            }
            </ToolkitProvider>
        </Container>
    );

} 