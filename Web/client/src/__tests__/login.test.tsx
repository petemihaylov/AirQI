import React from "react";
import ***REMOVED*** shallow***REMOVED*** from "enzyme";
import Login from "../components/pages/login";

test("renders the component", () => ***REMOVED***
  const component = shallow(<Login />);
  expect(component).toMatchSnapshot();
***REMOVED***);
