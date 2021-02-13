let params = (new URL(document.location)).searchParams;
let vehicle = params.get("vehicle");
let index = params.get("index");

console.log(vehicle,index)


let form_try = document.getElementById('form_try');
let form_buy = document.getElementById('form_buy');
let form_sell = document.getElementById('form_sell');





function setRoute(){
    form_try.action=`/trysell?vehicle=${vehicle}&index=${index}`;
    form_buy.action = `/buy?vehicle=${vehicle}&index=${index}`;
    form_sell.action = `/sell?vehicle=${vehicle}&index=${index}`;
}
setRoute()

