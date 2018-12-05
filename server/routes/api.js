const express = require('express');
const router = express.Router();

const NASDAQController = require('../controllers/NASDAQController')

router.get('/', function (req, res, next) {
  res.send('Welcome to cmov2 API!!!')
});

router.get('/stocks', NASDAQController.test)

module.exports = router;