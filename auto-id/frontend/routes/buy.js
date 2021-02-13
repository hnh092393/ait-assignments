var express = require('express');
var router = express.Router();

/* GET users listing. */
router.get('/', function(req, res, next) {
  console.log(req.params)
  res.send('respond with a resource');
});

router.post('/', async (req,res,next)=>{
  
  let amount = web3.utils.toWei(req.body.amount,'ether');   //Converts amount into wei
  let carAddress = req.query.vehicle;              //the car address     
  let bidderAddress = req.body.bidderAddress;      //the bidderAddress   
  console.log('POST +====>',amount,carAddress,bidderAddress)
  carInstance = web3.eth.Contract(CarAbi,carAddress); 
  
  try{
    let result =await carInstance.methods.buy().send({from:bidderAddress,value:amount,gas:6000000});
    res.send({success:result}); 
          

  }catch(e){
    console.log(e)
    res.send({error:e});

  }


})

module.exports = router;
