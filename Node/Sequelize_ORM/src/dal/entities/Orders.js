const Sequelize = require('sequelize');
module.exports = function(sequelize, DataTypes) {
  return sequelize.define('Orders', {
    OrderID: {
      autoIncrement: true,
      type: DataTypes.INTEGER,
      allowNull: false,
      primaryKey: true
    },
    CustomerID: {
      type: DataTypes.CHAR(5),
      allowNull: true,
      references: {
        model: 'Customers',
        key: 'CustomerID'
      }
    },
    EmployeeID: {
      type: DataTypes.INTEGER,
      allowNull: true,
      references: {
        model: 'Employees',
        key: 'EmployeeID'
      }
    },
    OrderDate: {
      type: DataTypes.DATE,
      allowNull: true
    },
    RequiredDate: {
      type: DataTypes.DATE,
      allowNull: true
    },
    ShippedDate: {
      type: DataTypes.DATE,
      allowNull: true
    },
    ShipVia: {
      type: DataTypes.INTEGER,
      allowNull: true,
      references: {
        model: 'Shippers',
        key: 'ShipperID'
      }
    },
    Freight: {
      type: DataTypes.DECIMAL(19,4),
      allowNull: true,
      defaultValue: 0
    },
    ShipName: {
      type: DataTypes.STRING(40),
      allowNull: true
    },
    ShipAddress: {
      type: DataTypes.STRING(60),
      allowNull: true
    },
    ShipCity: {
      type: DataTypes.STRING(15),
      allowNull: true
    },
    ShipRegion: {
      type: DataTypes.STRING(15),
      allowNull: true
    },
    ShipPostalCode: {
      type: DataTypes.STRING(10),
      allowNull: true
    },
    ShipCountry: {
      type: DataTypes.STRING(15),
      allowNull: true
    }
  }, {
    sequelize,
    tableName: 'Orders',
    schema: 'dbo',
    timestamps: false,
    indexes: [
      {
        name: "CustomerID",
        fields: [
          { name: "CustomerID" },
        ]
      },
      {
        name: "CustomersOrders",
        fields: [
          { name: "CustomerID" },
        ]
      },
      {
        name: "EmployeeID",
        fields: [
          { name: "EmployeeID" },
        ]
      },
      {
        name: "EmployeesOrders",
        fields: [
          { name: "EmployeeID" },
        ]
      },
      {
        name: "OrderDate",
        fields: [
          { name: "OrderDate" },
        ]
      },
      {
        name: "PK_Orders",
        unique: true,
        fields: [
          { name: "OrderID" },
        ]
      },
      {
        name: "ShippedDate",
        fields: [
          { name: "ShippedDate" },
        ]
      },
      {
        name: "ShippersOrders",
        fields: [
          { name: "ShipVia" },
        ]
      },
      {
        name: "ShipPostalCode",
        fields: [
          { name: "ShipPostalCode" },
        ]
      },
    ]
  });
};
