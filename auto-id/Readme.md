**Installation Guide**

The following prerequisites are required to run AutoID:
* Linux or macOS operation system (Debian-based OSes such as Ubuntu are recommended for beginners)
* Latest LTS Nodejs version
* Truffle
* Ganache-cli (not Ganache GUI)
* Ethereum with following options: geth --datadir "data" --rpc --rpcport "8545" --rpccorsdomain "*" --rpcapi "db,eth,net,web3,personal" --ipcpath "~/.ethereum/geth.ipc" --dev --unlock "0"
* Google Chrome with MetaMask extension

Steps to run the app on the local private network:
* Run terminal from the project folder
* Navigate terminal to "frontend" folder
* Run $npm install
* Run $ganache-cli
* Open another terminal from the root folder
* Run $truffle compile
* Take note of the transaction address shown on the terminal window
* Run $truffle migrate
* Navigate to "frontend" folder
* Run $npm start

Steps to run the app on the public networks:
* Deploy contracts in the "contracts" folder to Ethereum network, using Truffle or Remix IDE
* Navigate to "frontend" folder
* Run $npm start