let submitBtn = document.getElementById('enter');
let submitBtn2 = document.getElementById('addUser');
let addressInput = document.getElementById('address');
let displayEl = document.getElementById("display")

submitBtn.addEventListener('click',(e)=>{
    removeDisplayElements();
    let data = addressInput.value;
    console.log(data)
    fetch('',{
        method:'POST',
        headers: {
            "Content-Type": "application/json",
            // "Content-Type": "application/x-www-form-urlencoded",
        },
        body: JSON.stringify({data}),
    })
        .then(resp=>{
            if(resp.status!==200){
                resp.json()
                    .then(err=>{
                        displayElement(err.error,'error')
                    })
            }
            else{
                console.log(resp.status)
                return resp.json()
            }
            
        })
        .then(vehicles=>{
            if( vehicles !== undefined && vehicles.length>0 ){
                // console.log(`Hell`)

                vehicles.forEach((vehicle,index)=>{
                    displayElement(vehicle,index)
                    // console.log(`Inside cb`)

                })    
                

            }else if(vehicles.length===0){
                displayElement('Not registered','error')
            }

            
        })
        .catch(e=>{
            console.log(e)
        })
})

function displayElement(element,index){
    let queryString = makesQuery(element,index)
    let divEl = document.createElement('div');
    if(index === 'error'){
        let paraEl = document.createElement('p');
        paraEl.setAttribute("class",'error');
        paraEl.innerHTML = element;
        divEl.appendChild(paraEl);
        displayEl.appendChild(divEl);

    }
    else{
        console.log('inside')
        let paraEl = document.createElement('a');
        paraEl.setAttribute("class",'child');
        paraEl.innerHTML = element;
        paraEl.href = queryString;
        divEl.appendChild(paraEl);
        displayEl.appendChild(divEl);
    }


}
function removeDisplayElements(){
    while(displayEl.firstChild){
        displayEl.removeChild(displayEl.firstChild)
    }
}
function ownerInfo(e){
    if(e.target.tagName.toLowerCase() === 'p'){
        let data = e.target.innerHTML;
        fetch('/vehicle',{
            method:'POST',
            headers: {
                "Content-Type": "application/json",
                // "Content-Type": "application/x-www-form-urlencoded",
            },
            body: JSON.stringify({data}),
        })
        .then(resp=>{
            return resp.json()
        })
        .then(vehicleInfo=>{
            console.log(vehicleInfo);
        })
    }
}

displayEl.addEventListener('click',ownerInfo)

function makesQuery(vehicle,index){
    var params = {
        vehicle: vehicle,
        index: index
         
    };
    
    var esc = encodeURIComponent;
    var query = Object.keys(params)
        .map(k => esc(k) + '=' + esc(params[k]))
        .join('&');
      
    return sellLink = `/car?${query}`;
}

submitBtn2.addEventListener('click',addNewOwner);

function addNewOwner(e){
    let userAddress = document.getElementById('userAddress');
    let privateKey = document.getElementById('privateKey');
    let vinNo = document.getElementById('vinNo');
    let data = {userAddress:userAddress.value,vinNo:vinNo.value};
    console.log(data)
    fetch('/add',{
        method:'POST',
        headers: {
            "Content-Type": "application/json",
            // "Content-Type": "application/x-www-form-urlencoded",
        },
        body: JSON.stringify({data}),

    })
        .then(resp=>resp.json())
        .then(data=>{
            console.log(data)
        })
}

