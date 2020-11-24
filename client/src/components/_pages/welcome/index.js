import "./css/style.css";
import React from "react";
import { Container, Row, Col } from "react-bootstrap";
import { BubbleButton } from "../button/bubble";
import Fade from "react-reveal/Fade";
import { ReactComponent as SvgBackground } from "../../../assets/mind-map.svg";

export const WelcomePage = () => {
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
              <BubbleButton name={"Find even more"} />
            </a>
          </div>
        </Col>
        <Col>
          <SvgBackground style={{ width: "40vw", paddingLeft: "10vw" }} />
        </Col>
      </Row>
    </Container>
  );
};
