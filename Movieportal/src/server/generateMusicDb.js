const fs = require("fs");
const path = require("path");
const fakedb = require("./musicdata.js");
const { music } = fakedb;
const data = JSON.stringify({ music });
const fpath = path.join(__dirname, "db2.json");

fs.writeFile(fpath, data, function (err) {
  err ? console.log(err) : console.log("music Db Sample created..");
});
