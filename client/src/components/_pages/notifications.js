import ***REMOVED*** HubConnectionBuilder***REMOVED*** from "@microsoft/signalr";
import React, ***REMOVED*** useEffect, useState, useRef***REMOVED*** from "react";
import ***REMOVED*** Alert, Container, Row, Col***REMOVED*** from "react-bootstrap";
import ***REMOVED*** FontAwesomeIcon***REMOVED*** from "@fortawesome/react-fontawesome";
import ***REMOVED***
  faExclamationTriangle,
  faTrashAlt,
***REMOVED*** from "@fortawesome/free-solid-svg-icons";
import authHeader from "../../services/auth.header";
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
  const [connection, setConnection] = useState(null);
  const [notifications, setNotification] = useState([]);

  const handleDelete = (id, index) => ***REMOVED***
    props.dispatch(deleteNotification(id, index));
    handleContent(props.items);
 ***REMOVED***;

  ***REMOVED***
    /* Gets WebSocket notification */
 ***REMOVED***
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
            setNotification([Notification]);
         ***REMOVED***);
       ***REMOVED***)
        .catch((e) => console.log("Connection failed: ", e));
   ***REMOVED***
 ***REMOVED***, [connection]);

  ***REMOVED***  /* Gets notifications from DB */***REMOVED***

  useEffect(() => ***REMOVED***
    props.dispatch(fetchNotifications());
 ***REMOVED***, []);

  useEffect(() => ***REMOVED***
    handleContent(props.items);
 ***REMOVED***, [props.items]);

  return (
    <Container>
      <div
        style=***REMOVED******REMOVED*** height: "7vh", marginTop: "5vh"***REMOVED******REMOVED***
        className="d-flex flex-column align-items-center"
      >
        ***REMOVED***notifications &&
          notifications.map((m, idx) => (
            <Alert
              key=***REMOVED***idx***REMOVED***
              variant=***REMOVED***"danger"***REMOVED***
              style=***REMOVED******REMOVED*** width: "50vw", height: "45px"***REMOVED******REMOVED***
            >
              <FontAwesomeIcon icon=***REMOVED***faExclamationTriangle***REMOVED*** /> ***REMOVED***m.title***REMOVED******REMOVED***" "***REMOVED***
              ***REMOVED***m.description***REMOVED***
            </Alert>
          ))***REMOVED***
      </div>
      <div className="d-flex flex-column align-items-center">
        <div style=***REMOVED******REMOVED*** width: "50vw"***REMOVED******REMOVED***>
          <small>Notifications </small>
          <div className="border-bottom mb-4 mt-2" style=***REMOVED******REMOVED*** width: "50vw"***REMOVED******REMOVED***>
            ***REMOVED***" "***REMOVED***
          </div>
        </div>
        <div className="d-flex flex-column align-items-center">
          ***REMOVED***content.map((item, idx) => (
            <Alert
              key=***REMOVED***idx***REMOVED***
              variant=***REMOVED***"secondary"***REMOVED***
              style=***REMOVED******REMOVED*** width: "50vw", height: "45px"***REMOVED******REMOVED***
              className="d-flex align-items-center"
            >
              <div className="w-100 d-flex align-items-center justify-content-between">
                <div>
                  <FontAwesomeIcon
                    icon=***REMOVED***faExclamationTriangle***REMOVED***
                    className="mr-3"
                  />
                  ***REMOVED***item.title***REMOVED*** - ***REMOVED***item.description***REMOVED***
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
