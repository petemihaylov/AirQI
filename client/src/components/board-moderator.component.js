import React, { Component } from "react";
import UserService from "../services/user.service";

export default class BoardModerator extends Component {
    constructor(props) {
        super(props);

        this.state = {
          content: [],
        };
    }

    componentDidMount() {
        UserService.getModeratorBoard().then(
            response => {
                this.setState({
                  content: response.data,
                });
            },
            error => {
                this.setState({
                    content:
                        (error.response && error.response.data) ||
                        error.message ||
                        error.toString()
                });
            }
        );
    }

    render() {
        return (
          <div className="container">
            <header className="jumbotron">
              {this.state.content.map((item) => (
                <h4 key={item.id}>
                  {item.username},  
                  {item.firstName}, 
                  {item.lastName}
                </h4>
              ))}
            </header>
          </div>
        );
    }
}
