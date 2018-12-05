const express = require('express');
const bodyParser = require('body-parser');
const morgan = require('morgan')
const apiRouter = require('./routes/api');
const app = express();

app.use(bodyParser.json());
app.use(morgan('tiny'))
app.use('/api', apiRouter);

const port = 3000;
app.listen(port, '0.0.0.0', function(){
  console.log('Listen on port 3000');
});

module.exports = app;
