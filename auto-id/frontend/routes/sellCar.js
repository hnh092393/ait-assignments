var express = require('express');
var router = express.Router();

/* GET users listing. */
router.get('/', function(req, res, next) {
  res.send('respond with a resource');
});

router.post('/',async (req,res,next)=>{
  let owner = req.body.owner;
  let newOwner = req.body.newOwner;
  let index = req.body._id;

    carInstance.methods.sell(newOwner).send({from:owner,gas:6000000});
    // newCarInstance.methods.changeOwner(exOwner,newOwner,_id).send({from:owner,gas:6000000});
    res.send(`Owner Changed`);
    //Add code to change the owner

})

module.exports = router;
