import "./App.css";
import NavBar from "./components/Navbar";
import Nav from "./components/Nav2"
import Home from "./components/Home";
import AboutUs from "./components/AboutUs";
import MovieCarousel from "./components/Carousel";
import NavFooter from "./components/NavFooter";
import Music from "./components/Music";
// import { Navbar, Nav, Container, NavDropdown, Button } from "react-bootstrap";

// function App() {
//   let page = window.location.pathname;

//   if (page === "/about") return <AboutUs />;
//   return (
//     <div id="App">
//       <NavBar />
//       <MovieCarousel />
//       <Home />
//       <Movies />
//       <NavFooter />
//       <AboutUs />
//     </div>
//   );
// }

import { Route, Switch, Redirect } from "react-router-dom";
// import NavFooter from "./Common/NavFooter";
// import Home from "./Home/Home";
// import Contact from "./Contact/Contact";
// import About from "./About/About";
import PgNotFound from "./components/PgNotFound";
// import Movies from "./Movies/Movies";
import MusicDetail from "./components/MusicDetail";
import FormDemo from "./components/FormDemo";

function App(props) {
  return (
    <div className="container-fluid">
      {/* <NavFooter /> */}
      <Nav />
      <Switch>
        <Route path="/" exact component={Home} />

        <Route path="/musics" component={Music} />
        <Route path="/music1/:slug" component={MusicDetail} />
        <Route path="/music1" component={MusicDetail} />  

        {/* <Route path="/movies" component={Movies} />
        <Route path="/movie/:slug" component={MovieDetail} />
        <Route path="/movie" component={MovieDetail} />         */}
        
        <Route path="/about" component={AboutUs} />
        <Redirect from="/olpg" to="contact" />
        <Route component={PgNotFound} />
      </Switch>
      {/* <NavFooter /> */}
    </div>
  );
}


export default App;
