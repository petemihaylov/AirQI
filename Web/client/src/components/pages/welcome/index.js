import "./css/style.css";
import React from "react";
import { Container, Row, Col } from "react-bootstrap";
import Fade from "react-reveal/Fade";
import { ReactComponent as Svg } from "../../../assets/media/svg/mind-map.svg";
import { BubbleButton} from "../../../assets/js/button/bubble";

export const WelcomePage = () => {
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
              <BubbleButton name={"Find even more"} />
            </a>
          </div>
        </Col>
        <Col>
          <Svg style={{ width: "40vw", paddingLeft: "10vw" }} />
        </Col>
      </Row>
    </Container>
  );
};
