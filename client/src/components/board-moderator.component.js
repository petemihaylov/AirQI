import React, ***REMOVED*** Component***REMOVED*** from "react";
import UserService from "../services/user.service";

export default class BoardModerator extends Component ***REMOVED***
  constructor(props) ***REMOVED***
    super(props);

    this.state = ***REMOVED***
      content: [],
   ***REMOVED***;
 ***REMOVED***

  componentDidMount() ***REMOVED***
    UserService.getModeratorBoard().then(
      (response) => ***REMOVED***
        this.setState(***REMOVED***
          content: response.data,
       ***REMOVED***);
     ***REMOVED***,
      (error) => ***REMOVED***
        this.setState(***REMOVED***
          content:
            (error.response && error.response.data) ||
            error.message ||
            error.toString(),
       ***REMOVED***);
     ***REMOVED***
    );
 ***REMOVED***

  render() ***REMOVED***
    return (
      <div className="container">
        <UserList props=***REMOVED***this.state.content***REMOVED*** />
      </div>
    );
 ***REMOVED***
***REMOVED***

/* Listing users */

const UserList = (***REMOVED***props***REMOVED***) =>***REMOVED***
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
***REMOVED***
