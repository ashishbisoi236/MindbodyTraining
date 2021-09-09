import React from "react";

class FormDemoUnctrl extends React.Component {
  constructor(props) {
    super(props);


    this.handleSubmit = this.handleSubmit.bind(this);
    this.input = React.createRef();
  }

    handleSubmit(evt) {
    // this.setState({ value: evt.target.value });
    alert("uncontrolled by react" + this.input.current.value);
    evt.preventDefault();
  }

  render() {
    return (
      <form onSubmit={this.handleSubmit}>
        <label>
          Form2 name:
          <input
            type="text"
            ref={this.input}
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

export default FormDemoUnctrl;
