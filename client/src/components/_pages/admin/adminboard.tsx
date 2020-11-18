import ***REMOVED*** FontAwesomeIcon***REMOVED*** from "@fortawesome/react-fontawesome";
import React, ***REMOVED*** useEffect, useState***REMOVED*** from "react";
import ***REMOVED*** Container, Table***REMOVED*** from "react-bootstrap";
import User from "../../../entities/User";
import UserService from "../../../services/user.service";
import ***REMOVED*** faCog, faTimes***REMOVED*** from "@fortawesome/free-solid-svg-icons";
import "./css/style.css";

const AdminBoard = (props: any) => ***REMOVED***
  const [content, handleContent] = useState([]);

  useEffect(() => ***REMOVED***
    UserService.getPublicContent().then((response) => ***REMOVED***
      handleContent(response.data);
   ***REMOVED***);
 ***REMOVED***, []);

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
            content.map((item: User) => (
              <tr key=***REMOVED***item.id***REMOVED***>
                <td>***REMOVED***item.id***REMOVED***</td>
                <td> ***REMOVED***item.firstName***REMOVED*** ***REMOVED***item.lastName***REMOVED***</td>
                <td>04/10/2013</td>
                <td>***REMOVED***item.userRole***REMOVED***</td>
                <td>
                  <span className="status text-success">&bull;</span> Active
                </td>
                <td>
                  <a
                    href="#"
                    className="settings"
                    title="Settings"
                    data-toggle="tooltip"
                  >
                    <FontAwesomeIcon icon=***REMOVED***faCog***REMOVED*** />
                  </a>
                  <a
                    href="#"
                    className="delete"
                    title="Delete"
                    data-toggle="tooltip"
                  >
                    <FontAwesomeIcon icon=***REMOVED***faTimes***REMOVED*** />
                  </a>
                </td>
              </tr>
            ))***REMOVED***
        </tbody>
      </Table>
    </Container>
  );
***REMOVED***;

export default AdminBoard;
