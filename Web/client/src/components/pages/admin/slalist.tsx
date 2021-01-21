import React, { useEffect, useState } from "react";
import { connect } from "react-redux";
import { Card, Table } from "react-bootstrap";
import { fetchSlaMarkers } from "../../../actions/slamarker";
import { faShapes } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

const SlaList = (props: any) => {
  const [content, handleContent] = useState([]);

  useEffect(() => {
    handleContent(props.items);
  }, [props.items]);

  /* Fetches SlaMarkers from DB */
  useEffect(() => {
    props.dispatch(fetchSlaMarkers());
  }, []);

  return (
    <Card className="mb-5 mt-5 p-2">
      <Card.Title>
        <FontAwesomeIcon icon={faShapes} className="mr-2 mt-2 ml-2" /> Slas
      </Card.Title>
      <Card.Body className="mt-0">
        <Table responsive hover variant="light">
          <thead>
            <tr>
              <th></th>
              <th>Name</th>
              <th>Count</th>
              <th>Max</th>
            </tr>
          </thead>
          <tbody>
            {content !== [] &&
              content.map((item: any, index: number) => (
                <tr key={index}>
                  <td></td>
                  <td> {item.name}</td>
                  <td>{item.count}</td>
                  <td>{item.maxValue}</td>
                </tr>
              ))}
          </tbody>
        </Table>
      </Card.Body>
    </Card>
  );
};

function mapStateToProps(state: any) {
  const { items } = state.slamarkers;
  return {
    items,
  };
}

export default connect(mapStateToProps)(SlaList);
