pragma solidity ^0.5.0;

contract Car {
    uint price;
    
    struct ownerInfo {
        string vinNo;
        address payable owner;
        
    }
    
    uint public balance;
    uint public bidTime;
    ownerInfo public a1;
    
    address [] bidders;
    mapping(address=>uint) bids;
    mapping(address=>bool) serviceCenterAdd;
    //events
    event sellCarEvent(uint time , address previousOwner);
    event serviceCarEvent(uint time , address serviceCenter);
    event trySellEvent(uint time,uint bTime);
    
    constructor (address payable owner,string memory _vinNo) public{
        a1.vinNo = _vinNo;
        a1.owner = owner;
        
    }
    modifier onlyOwner{
        require(msg.sender == a1.owner);
        _;
    }
    
    modifier buyFn{
        require(msg.value>price);
        _;
    }
    
    function trySell(uint base,uint time) public onlyOwner {
        emit trySellEvent(now,bidTime);
        price = base;
        bidTime = now + time*1 minutes;
    }
    
    
    
    function sell(address payable newOwner) public onlyOwner{
        
        require(bids[newOwner] != 0);
        emit sellCarEvent (now , a1.owner);
        uint bid = bids[newOwner];
        // address payable owner = a1.owner;
        a1.owner.transfer(bid);
        a1.owner = newOwner;
        bids[newOwner] = 0;
        
        
        
        
        
    }
    function buy() payable public {
        require(now<bidTime);
        require(msg.value>price);
        bids[msg.sender]= msg.value;
        balance += msg.value;
        bidders.push(msg.sender);
        
    }
    
    function cashBack() public {
        require(bids[msg.sender] != 0);
        uint bid = bids[msg.sender];
        address payable oneBid = msg.sender;
        oneBid.transfer(bid);
        balance=balance-bid;
        bids[oneBid] = 0;
        
        
    }
    function service() public {
        require(serviceCenterAdd[msg.sender]);
        emit serviceCarEvent(now,msg.sender);
        
        
    }
    function returnBidders() public view returns(address [] memory _bidders,uint _length ){
        _bidders =  bidders;
        _length =  bidders.length;
    }
}