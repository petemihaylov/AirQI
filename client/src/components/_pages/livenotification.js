import { HubConnectionBuilder } from "@microsoft/signalr";
import React, { useEffect, useState, useRef } from "react";
import { Alert, Container, Row, Col } from "react-bootstrap";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faExclamationTriangle } from "@fortawesome/free-solid-svg-icons";
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
            style={{
              width: "100%",
              height: "40px",
              fontSize: "14px",
              display: "grid",
              alignItems: "center",
              padding: ".35rem 1.25rem",
            }}
          >
            <Row>
              <Col md={"1"}>
                <FontAwesomeIcon icon={faExclamationTriangle} />
              </Col>
              <Col md={"8"}>
                {m.title} {m.description}
              </Col>
              <Col md={"3"}>{m.createdAt}</Col>
            </Row>
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
