var express = require('express');
var router = express.Router();

/* GET users listing. */
router.get('/', function(req, res, next) {
  res.send('trySell');
});

router.post('/',async (req,res,next)=>{
  let carAddress = req.query.vehicle;
  let carIndex = req.query.index;
  let owner = req.body.owner;
  let base = req.body.base;
  let time = req.body.time;
  console.log('POST==>',carAddress,owner,base,time)

  try{
    carInstance = new web3.eth.Contract(CarAbi,carAddress);
    let result = await carInstance.methods.trySell(base,time).send({from:owner,gas:6000000})
    let resultofCar = await newCarInstance.methods.onSales(time,base,carIndex,carAddress).send({from:owner,gas:6000000})

    res.send({success:{result,resultofCar}});

  }catch(e){
    console.log(e);
    res.send({error:e});
  }

    
})
module.exports = router;
