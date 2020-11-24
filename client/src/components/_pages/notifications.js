import ***REMOVED*** HubConnectionBuilder***REMOVED*** from "@microsoft/signalr";
import React, ***REMOVED*** useEffect, useState, useRef***REMOVED*** from "react";
import ***REMOVED*** Alert, Container***REMOVED*** from "react-bootstrap";
import ***REMOVED*** FontAwesomeIcon***REMOVED*** from "@fortawesome/react-fontawesome";
import ***REMOVED*** faExclamationTriangle***REMOVED*** from "@fortawesome/free-solid-svg-icons";
import authHeader from "../../services/auth.header";

const ***REMOVED*** REACT_APP_API_URL***REMOVED*** = process.env;

const Notifications = () => ***REMOVED***
  const [connection, setConnection] = useState(null);
  const [Notification, setNotification] = useState([]);
  const latestNotification = useRef(null);

  latestNotification.current = Notification;

  useEffect(() => ***REMOVED***
    const newConnection = new HubConnectionBuilder()
      .withUrl(REACT_APP_API_URL + "/livenotification", ***REMOVED***
        headers: authHeader(),
     ***REMOVED***)
      .withAutomaticReconnect()
      .build();

    setConnection(newConnection);
 ***REMOVED***, []);

  useEffect(() => ***REMOVED***
    if (connection) ***REMOVED***
      connection
        .start()
        .then((result) => ***REMOVED***
          console.log("Connected!");

          connection.on("GetNewNotification", (Notification) => ***REMOVED***
            const updatedNotification = [...latestNotification.current];
            updatedNotification.push(Notification);

            setNotification(updatedNotification);
         ***REMOVED***);
       ***REMOVED***)
        .catch((e) => console.log("Connection failed: ", e));
   ***REMOVED***
 ***REMOVED***, [connection]);

  return (
    <Container>
      ***REMOVED***["secondary", "dark"].map((variant, idx) => (
        <Alert key=***REMOVED***idx***REMOVED*** variant=***REMOVED***variant***REMOVED***>
          <FontAwesomeIcon icon=***REMOVED***faExclamationTriangle***REMOVED*** /> Warning! There is
          alert - check it out!
        </Alert>
      ))***REMOVED***

      ***REMOVED***Notification &&
        Notification.map((m, idx) => (
          <Alert key=***REMOVED***idx***REMOVED*** variant=***REMOVED***"danger"***REMOVED***>
            <FontAwesomeIcon icon=***REMOVED***faExclamationTriangle***REMOVED*** /> ***REMOVED***m.title***REMOVED******REMOVED***" "***REMOVED***
            ***REMOVED***m.description***REMOVED***
          </Alert>
        ))***REMOVED***
    </Container>
  );
***REMOVED***;

export default Notifications;
