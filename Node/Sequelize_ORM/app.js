require('dotenv').config();
const express = require('express');
const app = express();
const CategoryRoute = require('./src/api/categoryAPI');
const CustomerAPI = require('./src/api/customerAPI');
const employeeAPI = require('./src/api/employeeAPI');
const employeeTerritoryAPI = require('./src/api/employeeTerritoryAPI');
const orderAPI = require('./src/api/orderAPI');
const orderDetailAPI = require('./src/api/orderDetailAPI');
const productAPI = require('./src/api/productAPI');
const regionAPI = require('./src/api/regionAPI');
const shipperAPI = require('./src/api/shipperAPI');
const supplierAPI = require('./src/api/supplierAPI');
const territoryAPI = require('./src/api/territoryAPI');
const testDatumAPI = require('./src/api/testDatumAPI');

app.use(express.json());
app.use('/categories', CategoryRoute);
app.use('/customers', CustomerAPI);
app.use('/employees', employeeAPI);
app.use('/employeeTerritories', employeeTerritoryAPI);
app.use('/orders', orderAPI);
app.use('/orderdetails', orderDetailAPI);
app.use('/products', productAPI);
app.use('/regions', regionAPI);
app.use('/shippers', shipperAPI);
app.use('/suppliers', supplierAPI);
app.use('/territories', territoryAPI);
app.use('/testData', testDatumAPI);

const PORT = process.env.PORT || 3000;
app.listen(PORT, () => {
  console.log(`Server running on port ${PORT}`);
});