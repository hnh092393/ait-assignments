pragma solidity ^0.5.0;

import "remix_tests.sol";
import "./Car.sol";

contract carTest{
    Car projTest;
    
    function beforeAll() public{
        projTest = new Car();
        
    }
    
    function checkName() public{
        Assert.equal(projTest.address(),address,"address should be present");
    }
    
    function checkSymbol() public{
        Assert.equal(projTest.vin(),vin,"vin is required");
    }
    
    
    
    
}
