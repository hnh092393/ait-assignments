var express = require('express');
var router = express.Router();

/* GET users listing. */
router.get('/', function(req, res, next) {
  res.send('respond with a resource');
});

router.post('/',async (req,res,next)=>{
    carInstance = web3.eth.Contract(CarAbi,req.body.data);
    let vehicleDetails =await carInstance.methods.a1.call();
    carInstance.getPastEvents('sellCarEvent',{fromBlock:0,toBlock:'latest'},(error,result)=>{
        console.log(result)
    })
    console.log(vehicleDetails.Regno,vehicleDetails.owner);
})

module.exports = router;
