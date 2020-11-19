import React from "react";
import { Container, FormControl, InputGroup } from "react-bootstrap";
import { faSearch } from "@fortawesome/free-solid-svg-icons";

import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
const Searchbar = (props: any) => {
  return (
    <form className="form-inline d-flex justify-content-center md-form form-sm mt-0">
      <FontAwesomeIcon icon={faSearch} arial-hidden="true" />
      <input
        className="form-control form-control-sm ml-3 w-75"
        type="text"
        placeholder="Search"
        aria-label="Search"
      />
    </form>
  );
};

export default Searchbar;
