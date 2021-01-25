import { HubConnectionBuilder } from "@microsoft/signalr";
import React, { useEffect, useState, useRef } from "react";
import { Alert, Container, Row, Col } from "react-bootstrap";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faExclamationTriangle,
  faTrashAlt,
} from "@fortawesome/free-solid-svg-icons";
import LiveNotification from "./livenotification";
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
  const [notifications, setNotification] = useState([]);

  const handleDelete = (id, index) => {
    props.dispatch(deleteNotification(id, index));
    handleContent(props.items);
  };

  /* Gets notifications from DB */
  useEffect(() => {
    props.dispatch(fetchNotifications());
  }, []);

  useEffect(() => {
    handleContent(props.items);
  }, [props.items]);

  return (
    <Container>
      <LiveNotification />
      <div className="d-flex flex-column align-items-center mt-5">
        <div style={{ width: "60vw" }}>
          <small>Notifications </small>
          <div className="border-bottom mb-4 mt-2" style={{ width: "60vw" }}>
            {" "}
          </div>
        </div>
        <div className="d-flex flex-column align-items-center">
          {content.map((item, idx) => (
            <Alert
              key={idx}
              variant={"secondary"}
              style={{
                width: "60vw",
                height: "45px",
                background: "#ffff",
                border: "dashed 2px #f89b1e",
              }}
              className="d-flex align-items-center"
            >
              <div className="w-100 d-flex align-items-center justify-content-between">
                <div>
                  <FontAwesomeIcon
                    icon={faExclamationTriangle}
                    className="mr-3"
                    style={{ color: "#f89b3e" }}
                  />
                  <b>{new Date(Date.now()).toDateString()}</b>
                  <span className="ml-5">{item.description}</span>
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
