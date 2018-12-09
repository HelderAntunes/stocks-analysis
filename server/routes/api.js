const express = require('express');
const router = express.Router();

const NASDAQController = require('../controllers/NASDAQController')
const CurrentQuotesController = require('../controllers/currentQuotesController')

router.get('/', function (req, res, next) {
  res.send('Welcome to cmov2 API!!!')
});

router.get('/stocks', NASDAQController.test)
router.get('/currentQuotes', CurrentQuotesController.test)

module.exports = router;