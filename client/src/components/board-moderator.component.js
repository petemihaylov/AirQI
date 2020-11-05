import PropTypes from "prop-types";
import React, { Component } from 'react';
import { connect } from 'react-redux';
import { fetchUsers } from '../actions/userActions';

class BoardModerator extends Component {
  componentDidMount() {
    this.props.fetchUsers();
  }

  render() {
    return (
      <div className="container">
        <UserList props={this.props.users} />
      </div>
    );
  }
}

BoardModerator.propTypes = {
  fetchUsers: PropTypes.func.isRequired,
  users: PropTypes.array.isRequired
}

/* Mapping state to props*/
const mapStateToProps = (state) => ({
  users: state.users.items,
});

/* Listing users */
const UserList = ({ props }) => {
  return (
    <div>
      <header className="jumbotron">
        {props &&
          props.map((item) => (
            <h4 key={item.id}>
              {item.username},{item.firstName},{item.lastName}
            </h4>
          ))}
      </header>
    </div>
  );
};

export default connect(mapStateToProps, { fetchUsers })(BoardModerator);
