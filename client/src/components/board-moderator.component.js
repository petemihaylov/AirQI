import PropTypes from "prop-types";
import React, ***REMOVED*** Component***REMOVED*** from 'react';
import ***REMOVED*** connect***REMOVED*** from 'react-redux';
import ***REMOVED*** fetchUsers***REMOVED*** from '../actions/userActions';

class BoardModerator extends Component ***REMOVED***
  componentDidMount() ***REMOVED***
    this.props.fetchUsers();
 ***REMOVED***

  render() ***REMOVED***
    return (
      <div className="container">
        <UserList props=***REMOVED***this.props.users***REMOVED*** />
      </div>
    );
 ***REMOVED***
***REMOVED***

BoardModerator.propTypes = ***REMOVED***
  fetchUsers: PropTypes.func.isRequired,
  users: PropTypes.array.isRequired
***REMOVED***

/* Mapping state to props*/
const mapStateToProps = (state) => (***REMOVED***
  users: state.users.items,
***REMOVED***);

/* Listing users */
const UserList = (***REMOVED*** props***REMOVED***) => ***REMOVED***
  return (
    <div>
      <header className="jumbotron">
        ***REMOVED***props &&
          props.map((item) => (
            <h4 key=***REMOVED***item.id***REMOVED***>
              ***REMOVED***item.username***REMOVED***,***REMOVED***item.firstName***REMOVED***,***REMOVED***item.lastName***REMOVED***
            </h4>
          ))***REMOVED***
      </header>
    </div>
  );
***REMOVED***;

export default connect(mapStateToProps, ***REMOVED*** fetchUsers***REMOVED***)(BoardModerator);
