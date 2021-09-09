import React, { useEffect, useState }  from "react";
import {getMusic} from "../apicalls/musicApi";
import MusicList from "./MusicList";
import {Link} from "react-router-dom";

function Music() {
  // useState
  const [music, setMusic] = useState([]);

  useEffect(() => {
    getMusic().then((_music) => setMusic(_music));
  }, []);

  return (
    <>
      <h4>Check out the blockbusters here..</h4>
      <Link className="btn btn-warning" to="/music1">Create Music</Link>
      <MusicList music={music}/>
    </>
  );
}

export default Music;
