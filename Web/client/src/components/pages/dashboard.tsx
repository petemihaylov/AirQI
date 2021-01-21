import React, { useEffect, useState } from "react";
import Map from "../map/map";
import LiveNotification from "./livenotification";

const Dashboard = (props: any) => {
  return (
    <div>
      <LiveNotification />
      <Map />
    </div>
  );
};

export default Dashboard;
