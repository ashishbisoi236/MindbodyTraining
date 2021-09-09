import React, { useEffect, useState } from "react";
import MusicForm from "./Musicform";
import toast from "react-hot-toast";
import * as musicApi from "../apicalls/musicApi";

const MusicDetail = (props) => {
  const [errors, setErrors] = useState({});
  const [music, setMusic] = useState({
    id: null,
    song: "",
    album: "",
    genre: "",
  });
  const [saving, setSave] = useState(false);

  useEffect(() => {
    const slug = props.match.params.slug; //"/musics/:slug"
    if (slug) {
      musicApi.getMusicbySlug(slug).then((_music) => setMusic(_music));
    }
  }, []);

  function ValidForm(params) {
    const _errors = {};
    if (!music.song) _errors.song = "Please enter the music song";
    if (!music.album) _errors.album = "Please select the actor ";
    if (!music.genre) _errors.genre = "Please enter the genre";
    setErrors(_errors);
    return Object.keys(_errors).length === 0;
  }

  //spread operator ...
  function handleChange({ target }) {
    setMusic({
      ...music,
      [target.name]: target.value,
    });
  }

  function handleSubmit(evt) {
    evt.preventDefault();
    if (!ValidForm()) return;
    setSave(true);
    musicApi.saveMusic(music).then(() => {
      console.log("Above toast");
      toast.success("Music created successfully", {duration: 3000});
      console.log("below toast");
      props.history.push("/musics");
    });
  }

  function handleDelete(evt) {
    evt.preventDefault();
    musicApi.deleteMusic(music.id).then(() => {
      props.history.push("/musics");
      alert("Music deleted..");
    });
  }

  return (
    <>
      <h2>Music Info</h2>
      <MusicForm
        errors={errors}
        music={music}
        saving={saving}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onDelete={handleDelete}
      />
    </>
  );
};
export default MusicDetail;
