var express = require('express');
var router = express.Router();

/* GET users listing. */
router.get('/', function(req, res, next) {
  res.send('respond with a resource');
});
router.post('/',async (req,res,next)=>{
    let data = req.body.data;
    console.log(data)
    let allVin = []
    try{
        let existingCars = await newCarInstance.getPastEvents('enterCar',{fromBlock:0,toBlock:'latest'});
        for(let i =0; i < existingCars.length; i++){
            allVin.push(existingCars[i].returnValues['vinNo']);
            console.log(`All vins==>`,allVin.indexOf(data.vinNo))

        }
        if(allVin.indexOf(data.vinNo)>-1){
            console.log('Already exists')
            res.send({error:'This car already exists'})
        }else{
            let what = await newCarInstance.methods.enterNewCar(data.vinNo).send({from:data.userAddress,gas:6000000})

            console.log("what")
            res.send({Success:what})
        }


    }catch(e){
        console.log(e)
        res.send({error:e})
    }
    
    
})

module.exports = router;    
