import React from "react";
import PropTypes  from "prop-types";

function MusicForm(props) {
  let containerClass = "form-group";
  if (props.errors.length > 0) {
    containerClass += "has-error";
  }
  return (
    <form onSubmit={props.onSubmit}>
      <div className={containerClass}>
        <label>Enter name of song</label>
        <div className="field">
          <input
            id="song"
            type="text"
            name="song"
            className="form-control"
            onChange={props.onChange}
            value={props.music.song}
          />
          {props.errors.song && (
            <div className="alert alert-danger">{props.errors.song}</div>
          )}
        </div>
      </div>

      <div className={containerClass}>
        <label>Enter name of Album</label>
        <div className="field">
          <input
            id="album"
            type="text"
            name="album"
            className="form-control"
            onChange={props.onChange}
            value={props.music.album}
          />
          {props.errors.album && (
            <div className="alert alert-danger">{props.errors.album}</div>
          )}
        </div>
      </div>

      {/* <div className={containerClass}>
        <label>Album</label>
        <div className="field">
          <select
            id="actor"
            name="actorId"
            onChange={props.onChange}
            className="form-control"
            value={props.music.actorId || ""}
          >
            <option value="" />
            <option value="1">Robert Downey</option>
            <option value="2">Scar Jo</option>
          </select>
        </div>
        {props.errors.actorId && (
          <div className="alert alert-danger">{props.errors.actorId}</div>
        )}
      </div> */}

      <div className={containerClass}>
        <label>Enter music Genre</label>
        <div className="field">
          <input
            id="genre"
            type="text"
            name="genre"
            onChange={props.onChange}
            className="form-control"
            value={props.music.genre}
          />
        </div>
        {props.errors.genre && (
          <div className="alert alert-danger">{props.errors.genre}</div>
        )}
      </div>

      <button type="submit" className="btn btn-warning" disabled={props.saving}>
        {props.saving ? "Saving.." : "Save"}
      </button>
      <input
        type="button"
        value="Delete Music"
        className="btn btn-danger"
        onClick={props.onDelete}
      />
    </form>
  );
}

MusicForm.propTypes = {
  music: PropTypes.object.isRequired,
  onSubmit: PropTypes.func.isRequired,
  onChange: PropTypes.func.isRequired,
  errors: PropTypes.object.isRequired,
};
export default MusicForm;
