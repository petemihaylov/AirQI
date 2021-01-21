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
          connection.on("GetNewNotification", (Notification) => ***REMOVED***
            console.log(Notification);
            setNotification([Notification]);
         ***REMOVED***);
       ***REMOVED***)
        .catch((e) => 
          console.log(***REMOVED***type: "livenotification", connection: "failed", error: e***REMOVED***));
   ***REMOVED***
 ***REMOVED***, [connection]);


  return (
    <Container
      style=***REMOVED******REMOVED*** position: "absolute", top: "3vh", left: "15vw", zIndex: "2"***REMOVED******REMOVED***
      onClick=***REMOVED***() => ***REMOVED***
        setNotification([]);
     ***REMOVED******REMOVED***
    >
      ***REMOVED***notifications &&
        notifications.map((m, idx) => (
          <Alert
            key=***REMOVED***idx***REMOVED***
            variant=***REMOVED***"default"***REMOVED***
            style=***REMOVED******REMOVED***
              width: "100%",
              background: "#f89b3e",
              height: "40px",
              fontSize: "14px",
              display: "grid",
              color: "white",
              alignItems: "center",
              padding: ".35rem 1.25rem",
           ***REMOVED******REMOVED***
          >
            <Row>
              <Col md=***REMOVED***"1"***REMOVED***>
                <FontAwesomeIcon icon=***REMOVED***faExclamationTriangle***REMOVED*** />
              </Col>
              <Col md=***REMOVED***"9"***REMOVED*** >
                ***REMOVED***m.title***REMOVED***! <span className="mr-5">  </span> ***REMOVED***m.description***REMOVED***
              </Col>
              <Col md=***REMOVED***"2"***REMOVED***>***REMOVED***m.createdAt***REMOVED***</Col>
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
