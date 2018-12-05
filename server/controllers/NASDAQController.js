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

    request(options, (error, response, body) => {
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
    })
  },
}