import { HubConnectionBuilder } from "@microsoft/signalr";
import React, { useEffect, useState } from 'react';
import fetchStationsData from '../services/pull_stations';

const { REACT_APP_API_URL } = process.env;
export default function Dashboard() {

    const [connection, setConnection] = useState(null);
    const [stations, setStationData] = useState([]);

    useEffect(() => {        
        const newConnection = new HubConnectionBuilder()
            .withUrl(REACT_APP_API_URL + "livestations")
            .withAutomaticReconnect()
            .build();
      
        setConnection(newConnection);
    }, []);

    useEffect(() => {
        fetchStationsData()
        .then(json => {
            setStationData(json.data);
        })
        .catch(err => {
            console.error(err.message);
        });
    }, []);

    useEffect(() => {
        if (connection) {
            connection
            .start()
            .then((result) => {
                console.log("Connected!");

                connection.on("GetNewStations", (station) => {
                setStationData([station]);
                });
            })
            .catch((e) => console.log("Connection failed: ", e));
        }
    }, [connection]);

    return (
        <div>
            {stations && stations.map(function(station, index){ 
                return (
                    <div>
                        {index}. Aqicn saved {station.location}
                    </div>
                )
            })}
        </div>
    );
} 