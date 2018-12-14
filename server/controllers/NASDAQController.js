const request = require('request')
const APIKEY = '306301356f2c6a2f1639eaab13d171b9'

module.exports = {
  test(req, res, next) {
    const params = req.query
    const type = params.type
    const startDate = params.startDate
    const company1 = params.company1
    const company2 = params.company2

    if (company1 === 'none' && company2 === 'none') {
      res.status(400).send({
        "status": {
          "code": 400,
          "message": "Some company must be selected."
        },
      })
      return;
    }

    if (company1 === 'none') {
      company1 = company2
      company2 = 'none';
    }

    let nameToTick = {};
    nameToTick['Apple'] = 'AAPL';
    nameToTick['IBM'] = 'IBM';
    nameToTick['Hewlett Packard'] = 'HPE';
    nameToTick['Microsoft'] = 'MSFT';
    nameToTick['Oracle'] = 'ORCL';
    nameToTick['Google'] = 'GOOGL';
    nameToTick['Facebook'] = 'FB';
    nameToTick['Twitter'] = 'TWTR';
    nameToTick['Intel'] = 'INTC';
    nameToTick['AMD'] = 'AMD';
    const maxRecords = type === 'week'? 7:30;

    const options = {
      url: 'https://marketdata.websol.barchart.com/getHistory.json?apikey=' + APIKEY +
        '&symbol=' + nameToTick[company1] + '&startDate=' + startDate + '&type=daily' + '&maxRecords=' + maxRecords,
    }
    console.log(options.url)
    
    request(options, (error, response, body) => {
      if (!error && response.statusCode == 200) {
        body = JSON.parse(body)
        const results1 = body.results

        if (company2 === 'none') {
          let resJSON = {
            "message": "Success.",
            "results1": results1,
            "results2": []
          }

          res.status(200).send(resJSON);
          return;
        } else {
          const options2 = {
            url: 'https://marketdata.websol.barchart.com/getHistory.json?apikey=' + APIKEY +
              '&symbol=' + nameToTick[company2] + '&startDate=' + startDate + '&type=daily' + '&maxRecords=' + maxRecords,
          }

          request(options2, (error, response, body) => {
            if (!error && response.statusCode == 200) {
              body = JSON.parse(body)
              resJSON = {
                "message": "Success.",
                "results1": results1,
                "results2": body.results
              }
              console.log(resJSON.results1.length)
              
              res.status(200).send(resJSON)
            } else {
              const resJSON = {
                'message': 'Some error happened.'
              }

              res.status(400).send(resJSON);
            }
          })
        }
      } else {
        const resJSON = {
          'message': 'Some error happened.'
        }

        res.status(400).send(resJSON);
      }
    })
  },
}