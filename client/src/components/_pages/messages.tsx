import React from "react";
import ***REMOVED*** Alert, Container***REMOVED*** from "react-bootstrap";

const Messages = () => ***REMOVED***
  return (
    <Container>
      ***REMOVED***[
        "primary",
        "secondary",
        "success",
        "danger",
        "warning",
        "info",
        "light",
        "dark",
      ].map((variant, idx) => (
        <Alert key=***REMOVED***idx***REMOVED*** variant=***REMOVED***variant***REMOVED***>
          This is a ***REMOVED***variant***REMOVED*** alert—check it out!
        </Alert>
      ))***REMOVED***
    </Container>
  );
***REMOVED***;

export default Messages;
