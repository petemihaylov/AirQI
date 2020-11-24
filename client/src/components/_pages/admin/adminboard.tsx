import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import React, { useEffect, useState } from "react";
import { Button, Col, Container, Row, Table } from "react-bootstrap";
import User from "../../../entities/User";
import {
  faCog,
  faTrashAlt,
  faUserPlus,
} from "@fortawesome/free-solid-svg-icons";
import { connect } from "react-redux";
import { deleteUser, fetchUsers } from "../../../actions/userActions";
import "./css/style.css";
import Searchbar from "./searchbar";
import CreateModal from "./create-modal";

const AdminBoard = (props: any) => {
  const [content, handleContent] = useState([]);
  const [modalShow, setModalShow] = React.useState(false);

  useEffect(() => {
    props.dispatch(fetchUsers());
    if (props.items !== []) handleContent(props.items);
  }, [props.items]);

  const handleDelete = (id: any, index: number) => {
    console.log(id + ", " + index);
    props.dispatch(deleteUser(id, index));
  };

  return (
    <Container>
      <Row className="d-flex align-items-center">
        <Col sm={8}>
          <Searchbar />
        </Col>
        <Col sm={4}>
          <Button
            variant="outline-dark"
            size="sm"
            className="pl-3 pr-3"
            onClick={() => setModalShow(true)}
          >
            <FontAwesomeIcon icon={faUserPlus} />
          </Button>
        </Col>
      </Row>
      <CreateModal
        show={modalShow}
        props={props}
        onHide={() => setModalShow(false)}
      />

      <Table responsive hover variant="light">
        <thead>
          <tr>
            <th></th>
            <th>Name</th>
            <th>Date Created</th>
            <th>Role</th>
            <th>Status</th>
            <th></th>
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
                  <span className="status text-info">&bull;</span> Active
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
                    <FontAwesomeIcon icon={faTrashAlt} />
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
