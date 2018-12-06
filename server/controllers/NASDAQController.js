const request = require('request')
const APIKEY = '306301356f2c6a2f1639eaab13d171b9'

module.exports = {
  test(req, res, next) {
    const params = req.query
    const type = params.type
    const startDate = params.startDate
    const company = params.company

    const options = {
      url: 'https://marketdata.websol.barchart.com/getHistory.json?apikey=' + APIKEY +
        '&symbol=' + company + '&startDate=' + startDate + '&type=' + type,
    }

    res.status(200).send({
      "status": {
        "code": 200,
        "message": "Success."
      },
      "results": [
        {
          "symbol": "INTC",
          "timestamp": "2018-07-01T00:00:00-04:00",
          "tradingDay": "2018-07-01",
          "open": 48.43873,
          "high": 52.6465,
          "low": 45.86073,
          "close": 47.51025,
          "volume": 23109455,
          "openInterest": null
        },
        {
          "symbol": "INTC",
          "timestamp": "2018-08-01T00:00:00-04:00",
          "tradingDay": "2018-08-01",
          "open": 47.47075,
          "high": 50.28355,
          "low": 45.90113,
          "close": 48.12712,
          "volume": 22639343,
          "openInterest": null
        },
        {
          "symbol": "INTC",
          "timestamp": "2018-09-01T00:00:00-04:00",
          "tradingDay": "2018-09-01",
          "open": 48.07744,
          "high": 48.12712,
          "low": 43.78445,
          "close": 46.99426,
          "volume": 24509135,
          "openInterest": null
        },
        {
          "symbol": "INTC",
          "timestamp": "2018-10-01T00:00:00-04:00",
          "tradingDay": "2018-10-01",
          "open": 46.49738,
          "high": 49.40906,
          "low": 42.09509,
          "close": 46.58682,
          "volume": 34223916,
          "openInterest": null
        },
        {
          "symbol": "INTC",
          "timestamp": "2018-11-01T00:00:00-04:00",
          "tradingDay": "2018-11-01",
          "open": 46.65638,
          "high": 49.32,
          "low": 46.45763,
          "close": 49.31,
          "volume": 26347922,
          "openInterest": null
        },
        {
          "symbol": "INTC",
          "timestamp": "2018-12-01T00:00:00-05:00",
          "tradingDay": "2018-12-01",
          "open": 50,
          "high": 50.495,
          "low": 47.675,
          "close": 47.75,
          "volume": 33132250,
          "openInterest": null
        }
      ]
    })
    /*request(options, (error, response, body) => {
      if (!error && response.statusCode == 200) {
        body = JSON.parse(body)
        console.log(body.results.length)
        res.status(200).send(body);
      } else {
        const resJSON = {
          'message': 'Some error happened.'
        }
        res.status(400).send(response);
      }
    })*/
  },
}