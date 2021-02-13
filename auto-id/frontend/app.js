var createError = require('http-errors');
var express = require('express');
const Web3 = require('web3');
var path = require('path');
var cookieParser = require('cookie-parser');
var logger = require('morgan');

var indexRouter = require('./routes/index');
var usersRouter = require('./routes/users');
var vehicleRouter = require('./routes/vehicle')
var addRouter = require('./routes/add');
var sellCarRouter = require('./routes/sellCar');
var buyRouter = require('./routes/buy');
var trySellRouter = require('./routes/trysell');
var sellRouter = require('./routes/sell');
var cashBackRouter = require('./routes/cashback');
var carRouter = require('./routes/car');
var salesRouter = require('./routes/sales');



var app = express();
web3 = new Web3("http://localhost:8545");
const newCarJSON = require("../build/contracts/newCar.json");
const CarJSON = require("../build/contracts/Car.json");

newCarAddress = newCarJSON.networks["1337"].address;
newCarAbi = newCarJSON.abi;
CarAbi = CarJSON.abi;

newCarInstance = new web3.eth.Contract(newCarAbi,newCarAddress);


// view engine setup
app.set('views', path.join(__dirname, 'views'));
app.set('view engine', 'hbs');

app.use(logger('dev'));
app.use(express.json());
app.use(express.urlencoded({ extended: false }));
app.use(cookieParser());
app.use(express.static(path.join(__dirname, 'public')));

app.use('/', indexRouter);
app.use('/users', usersRouter);
app.use('/vehicle', vehicleRouter);
app.use('/add',addRouter);
app.use('/sellCar',sellCarRouter);
app.use('/buy',buyRouter);
app.use('/trysell',trySellRouter);
app.use('/sell',sellRouter);
app.use('/cashback',cashBackRouter);
app.use('/car',carRouter);
app.use('/sales',salesRouter);
// catch 404 and forward to error handler
app.use(function(req, res, next) {
  next(createError(404));
});

// error handler
app.use(function(err, req, res, next) {
  // set locals, only providing error in development
  res.locals.message = err.message;
  res.locals.error = req.app.get('env') === 'development' ? err : {};

  // render the error page
  res.status(err.status || 500);
  res.render('error');
});

module.exports = app;
