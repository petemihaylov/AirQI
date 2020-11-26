import { HubConnectionBuilder } from "@microsoft/signalr";
import React, { useEffect, useState, useRef } from "react";
import { Alert, Container, Row, Col } from "react-bootstrap";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faExclamationTriangle,
  faTrashAlt,
} from "@fortawesome/free-solid-svg-icons";
import authHeader from "../../services/auth.header";
import { connect } from "react-redux";
import {
  fetchNotifications,
  deleteNotification,
} from "../../actions/notificationActions";

const { REACT_APP_API_URL } = process.env;

const Notifications = (props) => {
  // Stored notifications from the DB
  const [content, handleContent] = useState([]);
  

  // Live notifications from the WebSocket
  const [connection, setConnection] = useState(null);
  const [notifications, setNotification] = useState([]);

  const handleDelete = (id, index) => {
    props.dispatch(deleteNotification(id, index));
    handleContent(props.items);
  };

  {
    /* Gets WebSocket notification */
  }
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

  {  /* Gets notifications from DB */}

  useEffect(() => {
    props.dispatch(fetchNotifications());
  }, []);

  useEffect(() => {
    handleContent(props.items);
  }, [props.items]);

  return (
    <Container>
      <div
        style={{ height: "7vh", marginTop: "5vh" }}
        className="d-flex flex-column align-items-center"
      >
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
      </div>
      <div className="d-flex flex-column align-items-center">
        <div style={{ width: "50vw" }}>
          <small>Notifications </small>
          <div className="border-bottom mb-4 mt-2" style={{ width: "50vw" }}>
            {" "}
          </div>
        </div>
        <div className="d-flex flex-column align-items-center">
          {content.map((item, idx) => (
            <Alert
              key={idx}
              variant={"secondary"}
              style={{ width: "50vw", height: "45px" }}
              className="d-flex align-items-center"
            >
              <div className="w-100 d-flex align-items-center justify-content-between">
                <div>
                  <FontAwesomeIcon
                    icon={faExclamationTriangle}
                    className="mr-3"
                  />
                  {item.title} - {item.description}
                </div>
                <div>
                  <button
                    className="btn"
                    title="Delete"
                    onClick={handleDelete.bind(this, item.id, idx)}
                  >
                    <FontAwesomeIcon icon={faTrashAlt} />
                  </button>
                </div>
              </div>
            </Alert>
          ))}
        </div>
      </div>
    </Container>
  );
};

function mapStateToProps(state) {
  const { items } = state.notifications;
  return {
    items,
  };
}

export default connect(mapStateToProps)(Notifications);
