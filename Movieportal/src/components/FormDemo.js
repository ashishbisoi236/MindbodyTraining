import React from "react";

class FormDemo extends React.Component {
  constructor(props) {
    super(props);
    this.state = { value: "" };
    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  handleChange(evt) {
    this.setState({ value: evt.target.value });
  }

  handleSubmit(evt) {
    // this.setState({ value: evt.target.value });
    console.log("controlled by react" + this.state.value);
    evt.preventDefault();
  }

  render() {
    return (
      <form onSubmit={this.handleSubmit}>
        <label>
          Usr name:
          <input
            type="text"
            value={this.state.value}
            onChange={this.handleChange}
          />
        </label>
        <input
          type="submit"
          value="Save"
        />
      </form>
    );
  }
}

export default FormDemo;
