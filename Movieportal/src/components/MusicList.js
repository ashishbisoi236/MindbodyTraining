import React from "react";
import PropTypes from "prop-types";
import { Link } from "react-router-dom";

function MusicList(props) {
  return (
    <table className="table">
      <thead>
        <tr>
          <th>Song</th>
          <th>Album</th>
          <th>Genre</th>
        </tr>
      </thead>
      <tbody>
        {props.music.map((music) => {
          return (
            <tr key={music.id}>
              <Link to={"/music1/" + music.slug}>{music.song}</Link>
              <td>{music.album}</td>
              <td>{music.genre}</td>
            </tr>
          );
        })}
      </tbody>
    </table>
  );
}

MusicList.propTypes = {
  music: PropTypes.arrayOf(
    PropTypes.shape({
      id: PropTypes.number.isRequired,
      song: PropTypes.string.isRequired,
      album: PropTypes.string.isRequired,
      genre: PropTypes.string.isRequired,
    })
  ).isRequired,
};

MusicList.defaultProps = {
  music: [],
};

export default MusicList;
