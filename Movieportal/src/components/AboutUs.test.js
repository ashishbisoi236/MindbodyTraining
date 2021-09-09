import React from 'react';
import renderer from "react-test-renderer";
import AboutUs from "./AboutUs";

test("Creating a snapshot of AboutUs component", () => {
    const component = renderer.create(<AboutUs />);
    const treesnapshot = component.toJSON();
    expect(treesnapshot).toMatchSnapshot();
});