import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import React, { useEffect, useState } from "react";
import { Container, Table } from "react-bootstrap";
import User from "../../../entities/User";
import UserService from "../../../services/user.service";
import { faCog, faTimes } from "@fortawesome/free-solid-svg-icons";
import "./css/style.css";

const AdminBoard = (props: any) => {
  const [content, handleContent] = useState([]);

  useEffect(() => {
    UserService.getPublicContent().then((response) => {
      handleContent(response.data);
    });
  }, []);

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
          {content !== [] &&
            content.map((item: User) => (
              <tr key={item.id}>
                <td>{item.id}</td>
                <td> {item.firstName} {item.lastName}</td>
                <td>04/10/2013</td>
                <td>{item.userRole}</td>
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
                    <FontAwesomeIcon icon={faCog} />
                  </a>
                  <a
                    href="#"
                    className="delete"
                    title="Delete"
                    data-toggle="tooltip"
                  >
                    <FontAwesomeIcon icon={faTimes} />
                  </a>
                </td>
              </tr>
            ))}
        </tbody>
      </Table>
    </Container>
  );
};

export default AdminBoard;
