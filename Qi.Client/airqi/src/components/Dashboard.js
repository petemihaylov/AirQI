import React, { useEffect, useState } from 'react';
import fetchStationsData from '../services/pull_stations';

export default function Dashboard() {
    const [stations, setStationData] = useState([]);

    useEffect(() => {
        fetchStationsData()
            .then(json => {
                setStationData(json.data);
            })
            .catch(err => {
                console.error(err.message);
            });
        
    });

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