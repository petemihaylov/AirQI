import { HubConnectionBuilder } from "@microsoft/signalr";
import React, { useEffect, useState, useRef } from "react";
import { Alert, Container, Row, Col } from "react-bootstrap";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {faExclamationTriangle,} from "@fortawesome/free-solid-svg-icons";
import authHeader from "../../services/auth.header";
import { connect } from "react-redux";

const { REACT_APP_API_URL } = process.env;

const LiveNotification = (props) => {
  // Live notifications from the WebSocket
  const [connection, setConnection] = useState(null);
  const [notifications, setNotification] = useState([]);

  
  /* Gets WebSocket notification */
  useEffect(() => {
    const newConnection = new HubConnectionBuilder()
      .withUrl(REACT_APP_API_URL + "/livenotification", {
        headers: authHeader(),
      })
      .withAutomaticReconnect()
      .build();

    setConnection(newConnection);
  }, []);

  useEffect(() => {
    if (connection) {
      connection
        .start()
        .then((result) => {
          console.log("Connected!");

          connection.on("GetNewNotification", (Notification) => {
            setNotification([Notification]);
          });
        })
        .catch((e) => console.log("Connection failed: ", e));
    }
  }, [connection]);

  return (
    <Container>
        {notifications &&
          notifications.map((m, idx) => (
            <Alert
              key={idx}
              variant={"danger"}
              style={{ width: "50vw", height: "45px" }}
            >
              <FontAwesomeIcon icon={faExclamationTriangle} /> {m.title}{" "}
              {m.description}
            </Alert>
          ))}

    </Container>
  );
};

function mapStateToProps(state) {
  const { items } = state.notifications;
  return {
    items,
  };
}

export default connect(mapStateToProps)(LiveNotification);
