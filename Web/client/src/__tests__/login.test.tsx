import React from "react";
import { shallow } from "enzyme";
import Login from "../components/pages/login";

test("renders the component", () => {
  const component = shallow(<Login />);
  expect(component).toMatchSnapshot();
});
