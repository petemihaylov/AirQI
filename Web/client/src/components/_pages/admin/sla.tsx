import React, ***REMOVED*** useEffect***REMOVED*** from "react";
import ***REMOVED*** Card, Form, Row, Col, Button***REMOVED*** from "react-bootstrap";
import ***REMOVED*** connect***REMOVED*** from "react-redux";
import Polygon from "./polygon";
import ***REMOVED*** FontAwesomeIcon***REMOVED*** from "@fortawesome/react-fontawesome";
import ***REMOVED*** faShapes***REMOVED*** from "@fortawesome/free-solid-svg-icons";
import ***REMOVED*** useForm***REMOVED*** from "react-hook-form";

export const Sla = (props: any) => ***REMOVED***
  const ***REMOVED*** register, handleSubmit, errors***REMOVED*** = useForm();

  const onSubmit = (data: any) => ***REMOVED***
    console.log(data.name);
    console.log(data.max);
    console.log(JSON.stringify(props.items || " "));

    const ***REMOVED*** dispatch, history***REMOVED*** = props;
 ***REMOVED***;

  useEffect(() => ***REMOVED***
    console.log(props.items);
 ***REMOVED***, [props.items]);

  return (
    <Card className="mb-3">
      <Card.Body>
        <Card.Title>
          <FontAwesomeIcon icon=***REMOVED***faShapes***REMOVED*** className="mr-2" /> Edit
        </Card.Title>
        <small className="ml-4 pl-2">Edit SLA</small>

        <Card.Text className="mt-5">
          <Polygon />
          <Form onSubmit=***REMOVED***handleSubmit(onSubmit)***REMOVED*** className="mt-5">
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
                  ref=***REMOVED***register(***REMOVED*** required: true***REMOVED***)***REMOVED***
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
                  ref=***REMOVED***register(***REMOVED*** required: true***REMOVED***)***REMOVED***
                />
              </Col>
            </Row>
            <Row>
              <Col>
                ***REMOVED***errors.name && (
                  <small className="text-danger"> This is required</small>
                )***REMOVED***
              </Col>
              <Col>
                ***REMOVED***" "***REMOVED***
                ***REMOVED***errors.max && (
                  <small className="text-danger"> This is required</small>
                )***REMOVED***
              </Col>
            </Row>
            <Row className="mb-5">
              <Col>
                <Form.Label></Form.Label>
                <Button variant="dark" size="sm" type="submit">
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
***REMOVED***;

function mapStateToProps(state: any) ***REMOVED***
  const ***REMOVED*** items***REMOVED*** = state.features;
  return ***REMOVED***
    items,
 ***REMOVED***;
***REMOVED***

export default connect(mapStateToProps)(Sla);
