// config/db.js
require('dotenv').config();
const { Sequelize } = require('sequelize');
const initModels = require('../dal/entities/init-models');
const config = require('./config').development;

const sequelize = new Sequelize(
  config.database,
  config.username,
  config.password,
  {
    host: config.host,
    port: config.port,
    dialect: config.dialect,
    dialectOptions: config.dialectOptions,
    logging: false,
  }
);


const models = initModels(sequelize);

module.exports = {
  sequelize,
  models,
};
