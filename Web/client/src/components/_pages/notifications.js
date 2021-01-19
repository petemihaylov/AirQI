import ***REMOVED*** HubConnectionBuilder***REMOVED*** from "@microsoft/signalr";
import React, ***REMOVED*** useEffect, useState, useRef***REMOVED*** from "react";
import ***REMOVED*** Alert, Container, Row, Col***REMOVED*** from "react-bootstrap";
import ***REMOVED*** FontAwesomeIcon***REMOVED*** from "@fortawesome/react-fontawesome";
import ***REMOVED***
  faExclamationTriangle,
  faTrashAlt,
***REMOVED*** from "@fortawesome/free-solid-svg-icons";
import LiveNotification from "./livenotification";
import ***REMOVED*** connect***REMOVED*** from "react-redux";
import ***REMOVED***
  fetchNotifications,
  deleteNotification,
***REMOVED*** from "../../actions/notificationActions";

const ***REMOVED*** REACT_APP_API_URL***REMOVED*** = process.env;

const Notifications = (props) => ***REMOVED***
  // Stored notifications from the DB
  const [content, handleContent] = useState([]);

  // Live notifications from the WebSocket
  const [notifications, setNotification] = useState([]);

  const handleDelete = (id, index) => ***REMOVED***
    props.dispatch(deleteNotification(id, index));
    handleContent(props.items);
 ***REMOVED***;

  /* Gets notifications from DB */
  useEffect(() => ***REMOVED***
    props.dispatch(fetchNotifications());
 ***REMOVED***, []);

  useEffect(() => ***REMOVED***
    handleContent(props.items);
 ***REMOVED***, [props.items]);

  return (
    <Container>
      <LiveNotification />
      <div className="d-flex flex-column align-items-center mt-5">
        <div style=***REMOVED******REMOVED*** width: "60vw"***REMOVED******REMOVED***>
          <small>Notifications </small>
          <div className="border-bottom mb-4 mt-2" style=***REMOVED******REMOVED*** width: "60vw"***REMOVED******REMOVED***>
            ***REMOVED***" "***REMOVED***
          </div>
        </div>
        <div className="d-flex flex-column align-items-center">
          ***REMOVED***content.map((item, idx) => (
            <Alert
              key=***REMOVED***idx***REMOVED***
              variant=***REMOVED***"secondary"***REMOVED***
              style=***REMOVED******REMOVED***
                width: "60vw",
                height: "45px",
                background: "#ffff",
                border: "dashed 2px #f89b1e",
             ***REMOVED******REMOVED***
              className="d-flex align-items-center"
            >
              <div className="w-100 d-flex align-items-center justify-content-between">
                <div>
                  <FontAwesomeIcon
                    icon=***REMOVED***faExclamationTriangle***REMOVED***
                    className="mr-3"
                    style=***REMOVED******REMOVED*** color: "#f89b3e"***REMOVED******REMOVED***
                  />
                  <b>***REMOVED***new Date(Date.now()).toDateString()***REMOVED***</b>
                  <span className="ml-5">***REMOVED***item.description***REMOVED***</span>
                </div>
                <div>
                  <button
                    className="btn"
                    title="Delete"
                    onClick=***REMOVED***handleDelete.bind(this, item.id, idx)***REMOVED***
                  >
                    <FontAwesomeIcon icon=***REMOVED***faTrashAlt***REMOVED*** />
                  </button>
                </div>
              </div>
            </Alert>
          ))***REMOVED***
        </div>
      </div>
    </Container>
  );
***REMOVED***;

function mapStateToProps(state) ***REMOVED***
  const ***REMOVED*** items***REMOVED*** = state.notifications;
  return ***REMOVED***
    items,
 ***REMOVED***;
***REMOVED***

export default connect(mapStateToProps)(Notifications);
