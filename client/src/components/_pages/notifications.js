import { HubConnectionBuilder } from "@microsoft/signalr";
import React, { useEffect, useState, useRef } from "react";
import { Alert, Container } from "react-bootstrap";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faExclamationTriangle } from "@fortawesome/free-solid-svg-icons";
import authHeader from "../../services/auth.header";

const { REACT_APP_API_URL } = process.env;

const Notifications = () => {
  const [connection, setConnection] = useState(null);
  const [Notification, setNotification] = useState([]);
  const latestNotification = useRef(null);

  latestNotification.current = Notification;

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
            const updatedNotification = [...latestNotification.current];
            updatedNotification.push(Notification);

            setNotification(updatedNotification);
          });
        })
        .catch((e) => console.log("Connection failed: ", e));
    }
  }, [connection]);

  return (
    <Container>
      {["secondary", "dark"].map((variant, idx) => (
        <Alert key={idx} variant={variant}>
          <FontAwesomeIcon icon={faExclamationTriangle} /> Warning! There is
          alert - check it out!
        </Alert>
      ))}

      {Notification &&
        Notification.map((m, idx) => (
          <Alert key={idx} variant={"danger"}>
            <FontAwesomeIcon icon={faExclamationTriangle} /> {m.title}{" "}
            {m.description}
          </Alert>
        ))}
    </Container>
  );
};

export default Notifications;
