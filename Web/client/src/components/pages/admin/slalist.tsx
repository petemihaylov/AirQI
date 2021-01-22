import React, ***REMOVED*** useEffect, useState***REMOVED*** from "react";
import ***REMOVED*** connect***REMOVED*** from "react-redux";
import ***REMOVED*** Card, Table***REMOVED*** from "react-bootstrap";
import ***REMOVED*** fetchSlaMarkers, deleteSlaMarker***REMOVED*** from "../../../actions/slamarker";
import ***REMOVED*** faTrashAlt, faList***REMOVED*** from "@fortawesome/free-solid-svg-icons";
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

  const handleDelete = (id: any, index: number) => ***REMOVED***
    props.dispatch(deleteSlaMarker(id, index));
 ***REMOVED***;

  return (
    <Card className="mb-5 mt-5 p-2">
      <Card.Title>
        <FontAwesomeIcon icon=***REMOVED***faList***REMOVED*** className="mr-2 mt-2 ml-2" /> Slas
      </Card.Title>
      <Card.Body className="mt-0">
        <Table responsive hover variant="light">
          <thead>
            <tr>
              <th></th>
              <th>Name</th>
              <th>Max</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            ***REMOVED***content !== [] &&
              content.map((item: any, index: number) => (
                <tr key=***REMOVED***index***REMOVED***>
                  <td></td>
                  <td> ***REMOVED***item.name***REMOVED***</td>
                  <td>***REMOVED***item.maxValue***REMOVED***</td>
                  <td>
                    ***REMOVED***" "***REMOVED***
                    <button
                      className="delete"
                      title="Delete"
                      data-toggle="tooltip"
                      onClick=***REMOVED***handleDelete.bind(this, item.id, index)***REMOVED***
                    >
                      <FontAwesomeIcon icon=***REMOVED***faTrashAlt***REMOVED*** />
                    </button>
                  </td>
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
