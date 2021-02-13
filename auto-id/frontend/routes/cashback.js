var express = require('express');
var router = express.Router();

/* GET users listing. */
router.get('/', function(req, res, next) {
  res.send('respond with a resource');
});

router.post('/',async (req,res,next)=>{
    let carAddress = req.query.vehicle;
    let bidderAddress = req.body.bidderAddress;
    carInstance = web3.eth.Contract(CarAbi,carAddress);
    try{
        let result = await carInstance.methods.cashBack().send({from:bidderAddress});
        res.send(result)
    }catch(e){
        res.send(e);

    }
})

module.exports = router;
