import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import React, { useEffect, useState } from "react";
import { Container, Table } from "react-bootstrap";
import User from "../../../entities/User";
import UserService from "../../../services/user.service";
import { faCog, faTimes } from "@fortawesome/free-solid-svg-icons";
import "./css/style.css";
import { connect } from "react-redux";
import { deleteUser, fetchUsers } from "../../../actions/userActions";

const AdminBoard = (props: any) => {
  const [content, handleContent] = useState([]);

  useEffect(() => {
    props.dispatch(fetchUsers());
    if (props.items !== []) handleContent(props.items);
  }, [props.items]);

  const handleDelete = (id: any, index: number) => {
    console.log(id + ", " + index);
    props.dispatch(deleteUser(id, index));
  };

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
            content.map((item: User, index) => (
              <tr key={item.id}>
                <td>{item.id}</td>
                <td>
                  {" "}
                  {item.firstName} {item.lastName}
                </td>
                <td>04/10/2013</td>
                <td>{item.userRole}</td>
                <td>
                  <span className="status text-success">&bull;</span> Active
                </td>
                <td>
                  <button
                    className="settings"
                    title="Settings"
                    data-toggle="tooltip"
                  >
                    <FontAwesomeIcon icon={faCog} />
                  </button>
                  <button
                    className="delete"
                    title="Delete"
                    data-toggle="tooltip"
                    onClick={handleDelete.bind(this, item.id, index)}
                  >
                    <FontAwesomeIcon icon={faTimes} />
                  </button>
                </td>
              </tr>
            ))}
        </tbody>
      </Table>
    </Container>
  );
};

function mapStateToProps(state: any) {
  const { items } = state.users;
  return {
    items,
  };
}

export default connect(mapStateToProps)(AdminBoard);
