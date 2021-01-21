import React from "react";
import { connect } from 'react-redux'
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faPencilAlt} from "@fortawesome/free-solid-svg-icons";
const ProfileImage = (props: any) => {
    
  const { user } = props;

    return (
      <form className="d-flex flex-column align-items-center p-3 mb-5 mt-2">
        <img
          className="rounded-circle mb-2"
          src="https://i.pinimg.com/originals/07/0d/9f/070d9fa117f5c45d3efd306b8cfe5c08.gif"
          alt="Avatar"
          width={"130px"}
          height={"130px"}
        ></img>
        <button className="btn btn-sm">
          <FontAwesomeIcon icon={faPencilAlt} />{" "}
        </button>
      </form>
    );
}

function mapStateToProps(state: any) {
  const { user } = state.auth;
  return {
    user,
  };
}

export default connect(mapStateToProps)(ProfileImage);


