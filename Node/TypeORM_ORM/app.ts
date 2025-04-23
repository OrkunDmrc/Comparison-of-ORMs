import 'reflect-metadata';
import express from 'express';
import { AppDataSource } from './src/config/data-source';
import categoryRoute from './src/api/categoryAPI';
import customerAPI from './src/api/customerAPI';
import employeeAPI from './src/api/employeeAPI';
import orderAPI from './src/api/orderAPI';
import orderDetailAPI from './src/api/orderDetailAPI';
import productAPI from './src/api/productAPI';
import regionAPI from './src/api/regionAPI';
import shipperAPI from './src/api/shipperAPI';
import supplierAPI from './src/api/supplierAPI';
import territoryAPI from './src/api/territoryAPI';
import testDatumAPI from './src/api/testDatumAPI';

const app = express();
app.use(express.json());
app.use('/categories', categoryRoute);

app.use(express.json());
app.use('/categories', categoryRoute);
app.use('/customers', customerAPI);
app.use('/employees', employeeAPI);
app.use('/orders', orderAPI);
app.use('/orderdetails', orderDetailAPI);
app.use('/products', productAPI);
app.use('/regions', regionAPI);
app.use('/shippers', shipperAPI);
app.use('/suppliers', supplierAPI);
app.use('/territories', territoryAPI);
app.use('/testData', testDatumAPI);

AppDataSource.initialize()
  .then(() => {
    console.log('✅ Data Source initialized');
    app.listen(3000, () => console.log('🚀 Server running on http://localhost:3000'));
  })
  .catch((err) => {
    console.error('❌ Error during Data Source initialization:', err);
  });