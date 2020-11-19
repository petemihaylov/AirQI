import React from "react";
import { Alert, Container } from "react-bootstrap";

const Messages = () => {
  return (
    <Container>
      {[
        "primary",
        "secondary",
        "success",
        "danger",
        "warning",
        "info",
        "light",
        "dark",
      ].map((variant, idx) => (
        <Alert key={idx} variant={variant}>
          This is a {variant} alert—check it out!
        </Alert>
      ))}
    </Container>
  );
};

export default Messages;
