const request = require('request')
const APIKEY = '306301356f2c6a2f1639eaab13d171b9'

module.exports = {
    test(req, res, next) {
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

        const options = {
            url: 'https://marketdata.websol.barchart.com/getQuote.json?apikey=' + APIKEY +
                '&symbols=AAPL,IBM,HPE,MSFT,ORCL,GOOGL,FB,TWTR,INTC,AMD'
        }
        console.log(options.url)

        request(options, (error, response, body) => {
            if (!error && response.statusCode == 200) {
                body = JSON.parse(body)
                res.status(200).send(body)
            } else {
                const resJSON = {
                    'message': 'Some error happened.'
                }
                res.status(400).send(resJSON)
            }
        })
    },
}