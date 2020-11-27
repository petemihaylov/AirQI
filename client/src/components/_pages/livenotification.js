import ***REMOVED*** HubConnectionBuilder***REMOVED*** from "@microsoft/signalr";
import React, ***REMOVED*** useEffect, useState, useRef***REMOVED*** from "react";
import ***REMOVED*** Alert, Container, Row, Col***REMOVED*** from "react-bootstrap";
import ***REMOVED*** FontAwesomeIcon***REMOVED*** from "@fortawesome/react-fontawesome";
import ***REMOVED*** faExclamationTriangle***REMOVED*** from "@fortawesome/free-solid-svg-icons";
import authHeader from "../../services/auth.header";
import ***REMOVED*** connect***REMOVED*** from "react-redux";

const ***REMOVED*** REACT_APP_API_URL***REMOVED*** = process.env;

const LiveNotification = (props) => ***REMOVED***
  // Live notifications from the WebSocket
  const [connection, setConnection] = useState(null);
  const [notifications, setNotification] = useState([]);

  /* Gets WebSocket notification */
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

  return (
    <Container>
      ***REMOVED***notifications &&
        notifications.map((m, idx) => (
          <Alert
            key=***REMOVED***idx***REMOVED***
            variant=***REMOVED***"danger"***REMOVED***
            style=***REMOVED******REMOVED***
              width: "100%",
              height: "40px",
              fontSize: "14px",
              display: "grid",
              alignItems: "center",
              padding: ".35rem 1.25rem",
           ***REMOVED******REMOVED***
          >
            <Row>
              <Col md=***REMOVED***"1"***REMOVED***>
                <FontAwesomeIcon icon=***REMOVED***faExclamationTriangle***REMOVED*** />
              </Col>
              <Col md=***REMOVED***"8"***REMOVED***>
                ***REMOVED***m.title***REMOVED*** ***REMOVED***m.description***REMOVED***
              </Col>
              <Col md=***REMOVED***"3"***REMOVED***>***REMOVED***m.createdAt***REMOVED***</Col>
            </Row>
          </Alert>
        ))***REMOVED***
    </Container>
  );
***REMOVED***;

function mapStateToProps(state) ***REMOVED***
  const ***REMOVED*** items***REMOVED*** = state.notifications;
  return ***REMOVED***
    items,
 ***REMOVED***;
***REMOVED***

export default connect(mapStateToProps)(LiveNotification);
