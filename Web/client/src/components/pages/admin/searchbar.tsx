import React from "react";
import ***REMOVED*** faSearch***REMOVED*** from "@fortawesome/free-solid-svg-icons";

import ***REMOVED*** FontAwesomeIcon***REMOVED*** from "@fortawesome/react-fontawesome";
const Searchbar = (props: any) => ***REMOVED***
  return (
    <form className="form-inline d-flex justify-content-center md-form form-sm mt-0">
      <FontAwesomeIcon icon=***REMOVED***faSearch***REMOVED*** arial-hidden="true" />
      <input
        className="form-control form-control-sm ml-3 w-75"
        type="text"
        placeholder="Search"
        aria-label="Search"
      />
    </form>
  );
***REMOVED***;

export default Searchbar;
