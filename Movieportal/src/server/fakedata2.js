movies=[
    {"id":1, "title":"DDLJ" ,"star":"SRK","Genre":"Romance"},
    {"id":2, "title":"3Idiots" ,"star":"SRK","Genre":"Romance"},
    {"id":3, "title":"PK" ,"star":"SRK","Genre":"Romance"},
    {"id":4, "title":"PIKU" ,"star":"SRK","Genre":"Romance"},
];

const actors=[
    {id:1,name:"SRK"},
    {id:2,name:"SRK"},
    {id:3,name:"SRK"},
    {id:4,name:"SRK"},
];
const newMovie={
    id:null,
    title:"",
    actorId:null,
    Genre:"",
};

module.exports={
    newMovie,
    movies,
    actors,
};


//json-server
//npm i npm-run-all
//npm i cross-en
//npm i cross-env