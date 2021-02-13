var express = require('express');
var router = express.Router();

/* GET users listing. */
router.get('/',async function(req, res, next) {
    let {vehicle,index}= req.query;
    // console.log(`The ruery parameters`,vehicle , index);
    carInstance = web3.eth.Contract(CarAbi,vehicle);
    ownerInfo =await carInstance.methods.a1().call();
    previousUsers = await carInstance.getPastEvents('sellCarEvent',{fromBlock:0,toBlock:'latest'})
    service = await carInstance.getPastEvents('serviceCarEvent',{fromBlock:0,toBlock:'latest'})

    // res.render('car');
    // console.log(previousUsers)
    
    res.render('car',{ownerInfo,previousUsers,service})
});

module.exports = router;
