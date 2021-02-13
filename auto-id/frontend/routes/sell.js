var express = require('express');
var router = express.Router();

/* GET users listing. */
router.get('/', function(req, res, next) {
  res.send('respond with a resource');
});

router.post('',async (req,res,next)=>{
    let ownerAddress = req.body.owner;
    let newOwner = req.body.newOwner;
    let carAddress = req.query.vehicle;
    let carIndex = req.query.index;
    console.log('POST =====> ',ownerAddress,newOwner,carAddress,carIndex);
    // let _id = req.body._id;
    carInstance = web3.eth.Contract(CarAbi,carAddress);
    try{
        let result =await carInstance.methods.sell(newOwner).send({from:ownerAddress,gas:6000000});
        //add code to change owner in the car contract
        let result2 = newCarInstance.methods.changeOwner(ownerAddress,newOwner,carIndex,carAddress).send({from:ownerAddress,gas:6000000});
        

        res.send({success:result});
    }catch(e){
        console.log(e)
        res.send({error:e});

    }
})

module.exports = router;
