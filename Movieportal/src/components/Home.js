import React from "react";
import arcade from "../imgs/arcade.jpg";

// component
function Home() {
  const styleObj = {
    textAlign: "center",
    paddingTop: "30px",
  };
  return (
    <>
      <h2 style={styleObj}>Hello React Music Store</h2>

      <img src={arcade}></img>
      <p>
        <strong>IMDb</strong> (an <em>acronym</em> for Internet Music Database)
        is an online database of information related to films, television
        programs, home videos, video games, and streaming content online –
        including cast, production crew and personal biographies, plot
        summaries, trivia, ratings, and fan and critical reviews.
      </p>
    </>
  );
}

export default Home;
