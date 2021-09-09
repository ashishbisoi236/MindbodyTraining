import { ResponseChk, ErrorChk } from "./chkApi2";
let url = process.env.REACT_APP_API_URL + "/music/";

export function getMusic() {
  return fetch(url).then(ResponseChk).catch(ErrorChk);
}

export function getMusicbySlug(slug) {
  return fetch(url + "?slug=" + slug)
    .then((response) => {
      if (!response.ok)
        throw new Error("Music by slug cannot be retrieved ..error");
      return response.json().then((music) => {
        if (music.length !== 1)
          throw new Error("Cannot find the music - " + slug);
        return music[0];
      });
    })
    .catch(ErrorChk);
}

export function saveMusic(music) {
  console.log("inside saveMusic, music id: " + music.id);
  console.log("inside saveMusic, music: ");
  console.log(music);
  return fetch(url + (music.id || ""),
    {
      method: music.id ? "PUT" : "POST",
      headers: { "content-type": "application/json" },
      body: JSON.stringify({
        ...music,
      }),
    })
        .then(ResponseChk)
        .catch(ErrorChk);
}

export function deleteMusic(musicId) {
  return fetch(url + musicId, {
    method: "DELETE",
  })
    .then(ResponseChk)
    .catch(ErrorChk);
}
