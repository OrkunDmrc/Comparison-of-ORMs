const Sequelize = require('sequelize');
module.exports = function(sequelize, DataTypes) {
  return sequelize.define('Order Details', {
    OrderID: {
      type: DataTypes.INTEGER,
      allowNull: false,
      primaryKey: true,
      references: {
        model: 'Orders',
        key: 'OrderID'
      }
    },
    ProductID: {
      type: DataTypes.INTEGER,
      allowNull: false,
      primaryKey: true,
      references: {
        model: 'Products',
        key: 'ProductID'
      }
    },
    UnitPrice: {
      type: DataTypes.DECIMAL(19,4),
      allowNull: false,
      defaultValue: 0
    },
    Quantity: {
      type: DataTypes.SMALLINT,
      allowNull: false,
      defaultValue: 1
    },
    Discount: {
      type: DataTypes.REAL,
      allowNull: false,
      defaultValue: 0
    }
  }, {
    sequelize,
    tableName: 'Order Details',
    schema: 'dbo',
    timestamps: false,
    indexes: [
      {
        name: "OrderID",
        fields: [
          { name: "OrderID" },
        ]
      },
      {
        name: "OrdersOrder_Details",
        fields: [
          { name: "OrderID" },
        ]
      },
      {
        name: "PK_Order_Details",
        unique: true,
        fields: [
          { name: "OrderID" },
          { name: "ProductID" },
        ]
      },
      {
        name: "ProductID",
        fields: [
          { name: "ProductID" },
        ]
      },
      {
        name: "ProductsOrder_Details",
        fields: [
          { name: "ProductID" },
        ]
      },
    ]
  });
};
