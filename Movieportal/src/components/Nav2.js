import React from "react";
// import banner from "../../images/movbanner.jpg";
import logo from "../imgs/logo.jpg";
import PropTypes from "prop-types";
import { NavLink, Link } from "react-router-dom";

const navstyle = {
  backgroundColor: "wheat",
};

const mystyle = {
  color: "darkslateblue",
};

function Nav(props) {
  return (
    <>
      <nav className="navbar navbar-expand-lg navbar-light" style={navstyle}>
        <a className="navbar-brand" to="/">
          {/* <img src={logo}></img> */}
        </a>
        <button
          className="navbar-toggler"
          type="button"
          data-toggle="collapse"
          data-target="#navbarNav"
        >
          <span className="navbar-toggler-icon"></span>
        </button>
        <div className="collapse navbar-collapse" id="navbarNav">
          <ul className="navbar-nav">
            <li className="nav-item">
              <NavLink
                className="nav-link"
                to="/"
                activeStyle={{ color: "darkslateblue" }}
              >
                Home
              </NavLink>
            </li>
            <li className="nav-item">
              <NavLink className="nav-link" to="/musics">
                Music
              </NavLink>
            </li>
            <li className="nav-item">
              <Link className="nav-link" to="/contact">
                Contact
              </Link>
            </li>
            <li className="nav-item">
              <Link className="nav-link" to="/about">
                About Us
              </Link>
            </li>
          </ul>
        </div>
      </nav>

      {/* <img src={logo} className="img-fluid"></img> */}
    </>
  );
}
Nav.defaultProps = {
  name: "Prime Emusics",
  tag: 2,
};
Nav.propTypes = {
  name: PropTypes.string,
  tag: PropTypes.number,
};

export default Nav;
