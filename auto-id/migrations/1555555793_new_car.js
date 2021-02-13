const newCar = artifacts.require("newCar")
module.exports = function(deployer) {
  deployer.deploy(newCar);
  // Use deployer to state migration tasks.
};
