import React, { useEffect, useState } from 'react';
import fetchStationsData from '../services/pull_stations';

export default function Dashboard() {
    const [stations, setStationData] = useState([]);

    useEffect(() => {
        fetchStationsData()
            .then(json => {
                setStationData(json);
            })
            .catch(err => {
                console.error(err.message);
            });
        
    });

    return (
        <div>
            {stations && stations.map((value, idx) => { 
                return (
                    <div>
                     
                    </div>
                )
            })}
        </div>
    );
} 