// json server - github

const jsonServer = require("json-server");
const server = jsonServer.create();
const path = require("path");
const router = jsonServer.router(path.join(__dirname, "db2.json"));
const middlewares = jsonServer.defaults({
  static: "node_modules/json-server/dist",
});

// Set default middlewares (logger, static, cors and no-cache)
server.use(middlewares);

// To handle POST, PUT and PATCH you need to use a body-parser
// You can use the one used by JSON Server
server.use(jsonServer.bodyParser);
server.use(function (req, res, next) {
  setTimeout(next, 0);
});

server.use((req, res, next) => {
  if (req.method === "POST") {
    req.body.createdAt = Date.now();
  }
  // if (req.method === "PUT") {
  //   req.body.createdAt = Date.now();
  // }
  // Continue to JSON Server router
  next();
});

server.post("/musics/", function (req, res, next) {
  let error = checkmusic(req.body);
  if (error) {
    res.status(400).send(error);
  } else {
      console.log(req.body.song);
    req.body.slug = generateurlSlug(req.body.song);
    next();
  }
});

// server.put("/music1/", function (req, res, next) {
//   let error = checkmusic(req.body);
//   if (error) {
//     res.status(400).send(error);
//   } else {
//       console.log(req.body.song);
//     req.body.slug = generateurlSlug(req.body.song);
//     next();
//   }
// });

function generateurlSlug(value) {
  return value
    .replace(/[^a-z0-9_]+/gi, "-")
    .replace(/^-|-$/g, "")
    .toLowerCase();
};

function checkmusic(music) {
  if (!music.song) return "please return title";
  return "";
};

// Use default router
server.use(router);
server.listen(3001, () => {
  console.log("JSON Server is running at port 3001...");
});
