import React, ***REMOVED*** useEffect, useState***REMOVED*** from "react";
import User from "../entities/User";

import UserService from "../services/user.service";

const Dashboard = (props: any) => ***REMOVED***
  const [content, handleContent] = useState([]);

  useEffect(() => ***REMOVED***
    UserService.getPublicContent().then((response) => ***REMOVED***
      handleContent(response.data);
   ***REMOVED***);
 ***REMOVED***, []);

  return (
    <div className="container mt-5">
      <table className="table">
        <tbody>
          ***REMOVED***content !== [] &&
            content.map((item: User) => (
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
***REMOVED***;

export default Dashboard;
