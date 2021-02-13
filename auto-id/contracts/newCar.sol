pragma solidity ^0.5.0; 
import './Car.sol';

contract newCar{
    mapping(address=>Car[]) carRecords;
    // struct carArray{
    //     Car[]
    // }
    // Car[] deployedCarAddress; 
    
    event sell(uint time,uint bidTime,uint bid,Car vehicleAddress,uint index);
    event enterCar( address ownerAddress,string vinNo);
    constructor() public{
        
    }
    

    
    //Enter a new car record
    function enterNewCar(string memory _vinNo) public {
        Car newCarD = new Car(msg.sender,_vinNo);
        carRecords[msg.sender].push(newCarD);
        emit enterCar(msg.sender,_vinNo);
        
    }
    
    
    function getOwnerInfo(address i) public view returns (Car [] memory){
        return carRecords[i];
    }
    function changeOwner(address exOwner,address newOwner,uint index,Car carAddress) public {
        require(carRecords[msg.sender][index]==carAddress);
        Car vehicle = carRecords[exOwner][index];
        remove(exOwner,index);
        // delete carRecords[exOwner][index];
        
        carRecords[newOwner].push(vehicle);
        
    }
    function remove(address oldOwner,uint index) internal returns(Car[]memory) {
        require(index<=carRecords[oldOwner].length);
    
        for (uint i = index; i<carRecords[oldOwner].length-1; i++){
            carRecords[oldOwner][i] =carRecords[oldOwner][i+1];
        }
        delete carRecords[oldOwner][carRecords[oldOwner].length-1];
        carRecords[oldOwner].length--;
        return  carRecords[oldOwner];
    }    
    function onSales(uint _salesTime , uint _basePrice,uint index,Car carAddress) public {
        require(carRecords[msg.sender][index]==carAddress);
        emit sell(now,now+(_salesTime*1 minutes),_basePrice,carAddress,index);
    }
    
}