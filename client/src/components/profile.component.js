import React, ***REMOVED*** Component***REMOVED*** from "react";
import AuthService from "../services/auth.service";

export default class Profile extends Component ***REMOVED***
    constructor(props) ***REMOVED***
        super(props);

        this.state = ***REMOVED***
            currentUser: AuthService.getCurrentUser()
       ***REMOVED***;
   ***REMOVED***

    render() ***REMOVED***
        const ***REMOVED*** currentUser***REMOVED*** = this.state;

        return (
            <div className="container">
                <header className="jumbotron">
                    <h3>
                        <strong>***REMOVED***currentUser.username***REMOVED***</strong> Profile
          </h3>
                </header>
                
                <p>
                    <strong>Token:</strong>***REMOVED***" "***REMOVED***
                    ***REMOVED***currentUser.accessToken.substring(0, 20)***REMOVED*** ...***REMOVED***" "***REMOVED***
                    ***REMOVED***currentUser.accessToken.substr(currentUser.accessToken.length - 20)***REMOVED***
                </p>
                
                <p>
                    <strong>Id:</strong>***REMOVED***" "***REMOVED***
                    ***REMOVED***currentUser.id***REMOVED***
                </p>
                
                <p>
                    <strong>First Name:</strong>***REMOVED***" "***REMOVED***
                    ***REMOVED***currentUser.firstName***REMOVED***
                </p>

                <p>
                    <strong>Last Name:</strong>***REMOVED***" "***REMOVED***
                    ***REMOVED***currentUser.lastName***REMOVED***
                </p>
                
                <strong>Authorities:</strong>
                <ul>
                    ***REMOVED***currentUser.roles &&
                        currentUser.roles.map((role, index) => <li key=***REMOVED***index***REMOVED***>***REMOVED***role***REMOVED***</li>)***REMOVED***
                </ul>
                
            </div>
        );
   ***REMOVED***
***REMOVED***