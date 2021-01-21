import React, ***REMOVED*** useEffect, useState***REMOVED*** from "react";
import ***REMOVED*** connect***REMOVED*** from "react-redux";
import ***REMOVED*** Card, Table***REMOVED*** from "react-bootstrap";
import ***REMOVED*** fetchSlaMarkers***REMOVED*** from "../../../actions/slamarker";
import ***REMOVED*** faShapes***REMOVED*** from "@fortawesome/free-solid-svg-icons";
import ***REMOVED*** FontAwesomeIcon***REMOVED*** from "@fortawesome/react-fontawesome";

const SlaList = (props: any) => ***REMOVED***
  const [content, handleContent] = useState([]);

  useEffect(() => ***REMOVED***
    handleContent(props.items);
 ***REMOVED***, [props.items]);

  /* Fetches SlaMarkers from DB */
  useEffect(() => ***REMOVED***
    props.dispatch(fetchSlaMarkers());
 ***REMOVED***, []);

  return (
    <Card className="mb-5 mt-5 p-2">
      <Card.Title>
        <FontAwesomeIcon icon=***REMOVED***faShapes***REMOVED*** className="mr-2 mt-2 ml-2" /> Slas
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
            ***REMOVED***content !== [] &&
              content.map((item: any, index: number) => (
                <tr key=***REMOVED***index***REMOVED***>
                  <td></td>
                  <td> ***REMOVED***item.name***REMOVED***</td>
                  <td>***REMOVED***item.count***REMOVED***</td>
                  <td>***REMOVED***item.maxValue***REMOVED***</td>
                </tr>
              ))***REMOVED***
          </tbody>
        </Table>
      </Card.Body>
    </Card>
  );
***REMOVED***;

function mapStateToProps(state: any) ***REMOVED***
  const ***REMOVED*** items***REMOVED*** = state.slamarkers;
  return ***REMOVED***
    items,
 ***REMOVED***;
***REMOVED***

export default connect(mapStateToProps)(SlaList);
