import React from "react";
import { Card, Form, Row, Col, Button } from "react-bootstrap";
import { connect } from "react-redux";
import Polygon from "./polygon";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faShapes, faSignature, faSdCard } from "@fortawesome/free-solid-svg-icons";
export const Sla = (props: any) => {
  return (
    <Card className="mb-3">
      <Card.Body>
        <Card.Title>
          <FontAwesomeIcon icon={faShapes} className="mr-2" /> Edit
        </Card.Title>
        <small className="ml-4 pl-2">Edit SLA</small>

        <Card.Text className="mt-5">
          <Form>
            <Row>
              <Col>
                <Form.Label>
                  <b>Title</b>
                  <small className="ml-2">( Enter the SLA' name)</small>
                </Form.Label>
                <Form.Control placeholder="Enter name" size="sm" />
              </Col>
              <Col>
                <Form.Label>
                  <b className="mr-2">Markers</b>

                  <small>(Max value)</small>
                </Form.Label>
                <Form.Control
                  type="number"
                  name="max"
                  min="0"
                  max="100"
                  size="sm"
                  placeholder="0"
                />
              </Col>
            </Row>
            <Row className="mb-5">
              <Col>
                <Form.Label></Form.Label>
                <div>
                  <Button variant="outline-dark" size="sm">
                    <FontAwesomeIcon icon={faSdCard} className="mr-2" />
                    Save the changes
                  </Button>
                </div>
              </Col>
              <Col></Col>
            </Row>
          </Form>
          <Polygon />
        </Card.Text>
      </Card.Body>
    </Card>
  );
};

const mapStateToProps = (state: any) => ({});

const mapDispatchToProps = {};

export default connect(mapStateToProps, mapDispatchToProps)(Sla);
