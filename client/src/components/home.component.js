import React, ***REMOVED*** Component***REMOVED*** from "react";
import UserService from "./../services/user.service";

export default class Home extends Component ***REMOVED***
  constructor(props) ***REMOVED***
    super(props);

    this.state = ***REMOVED***
      content: [],
   ***REMOVED***;
 ***REMOVED***

  componentDidMount() ***REMOVED***
    UserService.getPublicContent().then(
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
      <div className="container mt-5">
        <table className="table">
          <tbody>
            ***REMOVED***this.state.content.map((item) => (
              <tr key=***REMOVED***item.id***REMOVED***>
                <td>***REMOVED***item.id***REMOVED***</td>
                <td>***REMOVED***item.username***REMOVED***</td>
                <td>***REMOVED***item.firstName***REMOVED***</td>
                <td>***REMOVED***item.lastName***REMOVED***</td>
              </tr>
            ))***REMOVED***
          </tbody>
        </table>
      </div>
    );
 ***REMOVED***
***REMOVED***
