import "./css/style.css";
import React from "react";
import ***REMOVED*** Container, Row, Col***REMOVED*** from "react-bootstrap";
import ***REMOVED*** BubbleButton***REMOVED*** from "../button/bubble";
import Fade from "react-reveal/Fade";
import ***REMOVED*** ReactComponent as SvgBackground***REMOVED*** from "../../../assets/mind-map.svg";

export const WelcomePage = () => ***REMOVED***
  return (
    <Container fluid className="welcome">
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
            <a href="/map">
              <BubbleButton name=***REMOVED***"Find even more"***REMOVED*** />
            </a>
          </div>
        </Col>
        <Col>
          <SvgBackground style=***REMOVED******REMOVED*** width: "40vw", paddingLeft: "10vw"***REMOVED******REMOVED*** />
        </Col>
      </Row>
    </Container>
  );
***REMOVED***;
