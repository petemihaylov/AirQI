import React from "react";
import { shallow } from "enzyme";
import Login from "../components/_pages/login";

test("renders the component", () => {
  const component = shallow(<Login />);
  expect(component).toMatchSnapshot();
});
