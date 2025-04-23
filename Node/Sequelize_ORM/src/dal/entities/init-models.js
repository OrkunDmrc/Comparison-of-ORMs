var DataTypes = require("sequelize").DataTypes;
var _Categories = require("./Categories");
var _Customers = require("./Customers");
var _EmployeeTerritories = require("./EmployeeTerritories");
var _Employees = require("./Employees");
var _OrderDetails = require("./OrderDetails");
var _Orders = require("./Orders");
var _Products = require("./Products");
var _Region = require("./Region");
var _Shippers = require("./Shippers");
var _Suppliers = require("./Suppliers");
var _Territories = require("./Territories");
var _TestData = require("./TestData");

function initModels(sequelize) {
  var Categories = _Categories(sequelize, DataTypes);
  var Customers = _Customers(sequelize, DataTypes);
  var EmployeeTerritories = _EmployeeTerritories(sequelize, DataTypes);
  var Employees = _Employees(sequelize, DataTypes);
  var OrderDetails = _OrderDetails(sequelize, DataTypes);
  var Orders = _Orders(sequelize, DataTypes);
  var Products = _Products(sequelize, DataTypes);
  var Region = _Region(sequelize, DataTypes);
  var Shippers = _Shippers(sequelize, DataTypes);
  var Suppliers = _Suppliers(sequelize, DataTypes);
  var Territories = _Territories(sequelize, DataTypes);
  var TestData = _TestData(sequelize, DataTypes);

  Employees.belongsToMany(Territories, { as: 'TerritoryID_Territories', through: EmployeeTerritories, foreignKey: "EmployeeID", otherKey: "TerritoryID" });
  Orders.belongsToMany(Products, { as: 'ProductID_Products', through: OrderDetails, foreignKey: "OrderID", otherKey: "ProductID" });
  Products.belongsToMany(Orders, { as: 'OrderID_Orders', through: OrderDetails, foreignKey: "ProductID", otherKey: "OrderID" });
  Territories.belongsToMany(Employees, { as: 'EmployeeID_Employees', through: EmployeeTerritories, foreignKey: "TerritoryID", otherKey: "EmployeeID" });
  Products.belongsTo(Categories, { as: "Category", foreignKey: "CategoryID"});
  Categories.hasMany(Products, { as: "Products", foreignKey: "CategoryID"});
  Orders.belongsTo(Customers, { as: "Customer", foreignKey: "CustomerID"});
  Customers.hasMany(Orders, { as: "Orders", foreignKey: "CustomerID"});
  EmployeeTerritories.belongsTo(Employees, { as: "Employee", foreignKey: "EmployeeID"});
  Employees.hasMany(EmployeeTerritories, { as: "EmployeeTerritories", foreignKey: "EmployeeID"});
  Employees.belongsTo(Employees, { as: "ReportsTo_Employee", foreignKey: "ReportsTo"});
  Employees.hasMany(Employees, { as: "Employees", foreignKey: "ReportsTo"});
  Orders.belongsTo(Employees, { as: "Employee", foreignKey: "EmployeeID"});
  Employees.hasMany(Orders, { as: "Orders", foreignKey: "EmployeeID"});
  OrderDetails.belongsTo(Orders, { as: "Order", foreignKey: "OrderID"});
  Orders.hasMany(OrderDetails, { as: "Order Details", foreignKey: "OrderID"});
  OrderDetails.belongsTo(Products, { as: "Product", foreignKey: "ProductID"});
  Products.hasMany(OrderDetails, { as: "Order Details", foreignKey: "ProductID"});
  Territories.belongsTo(Region, { as: "Region", foreignKey: "RegionID"});
  Region.hasMany(Territories, { as: "Territories", foreignKey: "RegionID"});
  Orders.belongsTo(Shippers, { as: "ShipVia_Shipper", foreignKey: "ShipVia"});
  Shippers.hasMany(Orders, { as: "Orders", foreignKey: "ShipVia"});
  Products.belongsTo(Suppliers, { as: "Supplier", foreignKey: "SupplierID"});
  Suppliers.hasMany(Products, { as: "Products", foreignKey: "SupplierID"});
  EmployeeTerritories.belongsTo(Territories, { as: "Territory", foreignKey: "TerritoryID"});
  Territories.hasMany(EmployeeTerritories, { as: "EmployeeTerritories", foreignKey: "TerritoryID"});

  return {
    Categories,
    Customers,
    EmployeeTerritories,
    Employees,
    OrderDetails,
    Orders,
    Products,
    Region,
    Shippers,
    Suppliers,
    Territories,
    TestData,
  };
}
module.exports = initModels;
module.exports.initModels = initModels;
module.exports.default = initModels;
