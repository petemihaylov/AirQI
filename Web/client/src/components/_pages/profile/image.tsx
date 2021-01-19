import React from "react";
import ***REMOVED*** connect***REMOVED*** from 'react-redux'
import ***REMOVED*** FontAwesomeIcon***REMOVED*** from "@fortawesome/react-fontawesome";
import ***REMOVED*** faPencilAlt***REMOVED*** from "@fortawesome/free-solid-svg-icons";
const ProfileImage = (props: any) => ***REMOVED***
    
  const ***REMOVED*** user***REMOVED*** = props;

    return (
      <form className="d-flex flex-column align-items-center p-3 mb-5 mt-2">
        <img
          className="rounded-circle mb-2"
          src="https://i.pinimg.com/originals/07/0d/9f/070d9fa117f5c45d3efd306b8cfe5c08.gif"
          alt="Avatar"
          width=***REMOVED***"130px"***REMOVED***
          height=***REMOVED***"130px"***REMOVED***
        ></img>
        <button className="btn btn-sm">
          <FontAwesomeIcon icon=***REMOVED***faPencilAlt***REMOVED*** />***REMOVED***" "***REMOVED***
        </button>
      </form>
    );
***REMOVED***

function mapStateToProps(state: any) ***REMOVED***
  const ***REMOVED*** user***REMOVED*** = state.auth;
  return ***REMOVED***
    user,
 ***REMOVED***;
***REMOVED***

export default connect(mapStateToProps)(ProfileImage);


