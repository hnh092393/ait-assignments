var express = require('express');
var router = express.Router();

/* GET users listing. */
router.get('/', async function(req, res, next) {
    let timeUpForSales,carCurrent = [];
    let carsForSales = await newCarInstance.getPastEvents('sell',{fromBlock:0,toBlock:'latest'});
    for(let i = 0 ; i<carsForSales.length; i++){
        timeUpForSales = carsForSales[i].returnValues['bidTime'];
        let milliseconds = (new Date).getTime();
        console.log(timeUpForSales>(milliseconds/1000))
        if(timeUpForSales>milliseconds/1000){
            let timeLeft = Math.floor((timeUpForSales - (milliseconds/1000))/60)
            carsForSales[i].returnValues['timeLeft']= timeLeft;
            carCurrent.push(carsForSales[i].returnValues) 
        }
    }

    res.render('sales',{carCurrent});
  
});

module.exports = router;
