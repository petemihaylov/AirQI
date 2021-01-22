import React, ***REMOVED*** useEffect, useState***REMOVED*** from "react";
import ***REMOVED***
  Button,
  Col,
  Container,
  Row,
  Table,
  Collapse,
  InputGroup,
  Card,
***REMOVED*** from "react-bootstrap";
import User from "../../../entities/User";
import ***REMOVED*** FontAwesomeIcon***REMOVED*** from "@fortawesome/react-fontawesome";
import ***REMOVED***
  faCog,
  faTrashAlt,
  faUserPlus,
***REMOVED*** from "@fortawesome/free-solid-svg-icons";
import ***REMOVED*** connect***REMOVED*** from "react-redux";
import ***REMOVED*** deleteUser, fetchUsers***REMOVED*** from "../../../actions/userActions";
import "./css/style.css";
import Searchbar from "./searchbar";
import CreateModal from "./create-modal";
import Sla from "./sla";
import SlaList from "./slalist";

const AdminBoard = (props: any) => ***REMOVED***
  const [content, handleContent] = useState([]);
  const [modalShow, setModalShow] = React.useState(false);

  useEffect(() => ***REMOVED***
    props.dispatch(fetchUsers());
 ***REMOVED***, []);

  useEffect(() => ***REMOVED***
    handleContent(props.items);
    console.log(props.items);
 ***REMOVED***, [props.items]);

  const handleDelete = (id: any, index: number) => ***REMOVED***
    props.dispatch(deleteUser(id, index));
 ***REMOVED***;

  return (
    <Container>
      <Row className="d-flex align-items-center">
        <Col sm=***REMOVED***8***REMOVED***>
          <Searchbar />
        </Col>
        <Col sm=***REMOVED***4***REMOVED***>
          <Button
            variant="dark"
            size="sm"
            className="pl-3 pr-3"
            onClick=***REMOVED***() => setModalShow(true)***REMOVED***
          >
            <FontAwesomeIcon icon=***REMOVED***faUserPlus***REMOVED*** />
          </Button>
        </Col>
      </Row>
      <CreateModal
        show=***REMOVED***modalShow***REMOVED***
        props=***REMOVED***props***REMOVED***
        onHide=***REMOVED***() => setModalShow(false)***REMOVED***
      />

      <Card className="mb-5 mt-5">
        <Card.Body>
          <Table responsive hover variant="light">
            <thead>
              <tr>
                <th></th>
                <th>Name</th>
                <th>Last Active</th>
                <th>Role</th>
                <th>Status</th>
                <th></th>
              </tr>
            </thead>
            <tbody>
              ***REMOVED***content !== [] &&
                content.map((item: User, index) => (
                  <tr key=***REMOVED***index***REMOVED***>
                    <td>***REMOVED***index + 1***REMOVED***</td>
                    <td>
                      ***REMOVED***" "***REMOVED***
                      ***REMOVED***item.firstName***REMOVED*** ***REMOVED***item.lastName***REMOVED***
                    </td>
                    <td>***REMOVED***item.lastActive***REMOVED***</td>
                    <td>***REMOVED***item.userRole***REMOVED***</td>
                    <td>
                      <span className="status">&bull;</span>***REMOVED***" "***REMOVED***
                      ***REMOVED***item.isActive ? "Active" : "Inactive"***REMOVED***
                    </td>
                    <td>
                      <button
                        className="settings"
                        title="Settings"
                        data-toggle="tooltip"
                      >
                        <FontAwesomeIcon icon=***REMOVED***faCog***REMOVED*** />
                      </button>
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

      <Sla />
      <SlaList />
    </Container>
  );
***REMOVED***;

function mapStateToProps(state: any) ***REMOVED***
  const ***REMOVED*** items***REMOVED*** = state.users;
  return ***REMOVED***
    items,
 ***REMOVED***;
***REMOVED***

export default connect(mapStateToProps)(AdminBoard);
