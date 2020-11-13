import React, { useEffect, useState } from "react";
import User from "../entities/User";

import UserService from "../services/user.service";

const Dashboard = (props: any) => {
  const [content, handleContent] = useState([]);

  useEffect(() => {
    UserService.getPublicContent().then((response) => {
      handleContent(response.data);
    });
  }, []);

  return (
    <div className="container mt-5">
      <table className="table">
        <tbody>
          {content !== [] &&
            content.map((item: User) => (
              <tr key={item.id}>
                <td>{item.id}</td>
                <td>{item.username}</td>
                <td>{item.firstName}</td>
                <td>{item.lastName}</td>
              </tr>
            ))}
        </tbody>
      </table>
    </div>
  );
};

export default Dashboard;
