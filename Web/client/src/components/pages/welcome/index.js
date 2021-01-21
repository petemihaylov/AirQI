import "./css/style.css";
import React from "react";
import ***REMOVED*** Container, Row, Col***REMOVED*** from "react-bootstrap";
import Fade from "react-reveal/Fade";
import ***REMOVED*** ReactComponent as Svg***REMOVED*** from "../../../assets/media/svg/mind-map.svg";
import ***REMOVED*** BubbleButton***REMOVED*** from "../../../assets/js/button/bubble";

export const WelcomePage = () => ***REMOVED***
  return (
    <Container className="welcome">
      <Row>
        <Col>
          <Fade bottom>
            <div className="title">
              Air Quality Index
            </div>
            <div className="sub">
              A web platform that integrates air data and provides access to the
              latest information.
            </div>
          </Fade>
          <div className="btn">
            <a href="/login">
              <BubbleButton name=***REMOVED***"Find even more"***REMOVED*** />
            </a>
          </div>
        </Col>
        <Col>
          <Svg style=***REMOVED******REMOVED*** width: "40vw", paddingLeft: "10vw"***REMOVED******REMOVED*** />
        </Col>
      </Row>
    </Container>
  );
***REMOVED***;
