import ***REMOVED*** FontAwesomeIcon***REMOVED*** from "@fortawesome/react-fontawesome";
import React, ***REMOVED*** useEffect, useState***REMOVED*** from "react";
import ***REMOVED*** Container, Table***REMOVED*** from "react-bootstrap";
import User from "../../../entities/User";
import UserService from "../../../services/user.service";
import ***REMOVED*** faCog, faTimes***REMOVED*** from "@fortawesome/free-solid-svg-icons";
import "./css/style.css";
import ***REMOVED*** connect***REMOVED*** from "react-redux";
import ***REMOVED*** deleteUser, fetchUsers***REMOVED*** from "../../../actions/userActions";

const AdminBoard = (props: any) => ***REMOVED***
  const [content, handleContent] = useState([]);

  useEffect(() => ***REMOVED***
    props.dispatch(fetchUsers());
    if (props.items !== []) handleContent(props.items);
 ***REMOVED***, [props.items]);

  const handleDelete = (id: any, index: number) => ***REMOVED***
    console.log(id + ", " + index);
    props.dispatch(deleteUser(id, index));
 ***REMOVED***;

  return (
    <Container fluid>
      <Table responsive hover variant="dark">
        <thead>
          <tr>
            <th>#</th>
            <th>Name</th>
            <th>Date Created</th>
            <th>Role</th>
            <th>Status</th>
            <th>Action</th>
          </tr>
        </thead>
        <tbody>
          ***REMOVED***content !== [] &&
            content.map((item: User, index) => (
              <tr key=***REMOVED***item.id***REMOVED***>
                <td>***REMOVED***item.id***REMOVED***</td>
                <td>
                  ***REMOVED***" "***REMOVED***
                  ***REMOVED***item.firstName***REMOVED*** ***REMOVED***item.lastName***REMOVED***
                </td>
                <td>04/10/2013</td>
                <td>***REMOVED***item.userRole***REMOVED***</td>
                <td>
                  <span className="status text-success">&bull;</span> Active
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
                    <FontAwesomeIcon icon=***REMOVED***faTimes***REMOVED*** />
                  </button>
                </td>
              </tr>
            ))***REMOVED***
        </tbody>
      </Table>
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
