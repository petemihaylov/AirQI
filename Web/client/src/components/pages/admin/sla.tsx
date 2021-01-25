import React, { useEffect } from "react";
import { Card, Form, Row, Col, Button } from "react-bootstrap";
import { connect } from "react-redux";
import { useForm } from "react-hook-form";
import Polygon from "./polygon";
import { createSlaMarker } from "../../../actions/slamarker";
import { faShapes } from "@fortawesome/free-solid-svg-icons";

import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import SlaMarker from "../../../entities/SlaMarker";

const Sla = (props: any) => {
  const { register, handleSubmit, errors } = useForm();

  const onSubmit = (data: any) => {
    props.dispatch(
      createSlaMarker(new SlaMarker(data.name, 0, parseInt(data.max), JSON.stringify(props.items)))
    );
  };

  return (
    <Card className="mb-3">
      <Card.Body>
        <Card.Title>
          <FontAwesomeIcon icon={faShapes} className="mr-2" /> Edit
        </Card.Title>
        <small className="ml-4 pl-2">Edit SLA</small>
        <Polygon />
        <Card.Text className="mt-5">
          <Form onSubmit={handleSubmit(onSubmit)} className="mt-5">
            <Row>
              <Col>
                <Form.Label>
                  <b>Title</b>
                  <small className="ml-2">( Enter the SLA' name)</small>
                </Form.Label>
                <Form.Control
                  placeholder="Enter name"
                  size="sm"
                  name="name"
                  ref={register({ required: true })}
                />
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
                  ref={register({ required: true })}
                />
              </Col>
            </Row>
            <Row>
              <Col>
                {errors.name && (
                  <small className="text-danger"> This is required</small>
                )}
              </Col>
              <Col>
                {" "}
                {errors.max && (
                  <small className="text-danger"> This is required</small>
                )}
              </Col>
            </Row>
            <Row className="mb-5">
              <Col>
                <Form.Label></Form.Label>
                <Button
                  variant="light"
                  size="sm"
                  type="submit"
                  className="pr-5 pl-5"
                  style={{ border: "1px solid #f7f7f7" }}
                >
                  Save
                </Button>
              </Col>
              <Col></Col>
            </Row>
          </Form>
        </Card.Text>
      </Card.Body>
    </Card>
  );
};

function mapStateToProps(state: any) {
  const { items } = state.features;
  return {
    items,
  };
}

export default connect(mapStateToProps)(Sla);
