const Sequelize = require('sequelize');
module.exports = function(sequelize, DataTypes) {
  return sequelize.define('Products', {
    ProductID: {
      autoIncrement: true,
      type: DataTypes.INTEGER,
      allowNull: false,
      primaryKey: true
    },
    ProductName: {
      type: DataTypes.STRING(40),
      allowNull: false
    },
    SupplierID: {
      type: DataTypes.INTEGER,
      allowNull: true,
      references: {
        model: 'Suppliers',
        key: 'SupplierID'
      }
    },
    CategoryID: {
      type: DataTypes.INTEGER,
      allowNull: true,
      references: {
        model: 'Categories',
        key: 'CategoryID'
      }
    },
    QuantityPerUnit: {
      type: DataTypes.STRING(20),
      allowNull: true
    },
    UnitPrice: {
      type: DataTypes.DECIMAL(19,4),
      allowNull: true,
      defaultValue: 0
    },
    UnitsInStock: {
      type: DataTypes.SMALLINT,
      allowNull: true,
      defaultValue: 0
    },
    UnitsOnOrder: {
      type: DataTypes.SMALLINT,
      allowNull: true,
      defaultValue: 0
    },
    ReorderLevel: {
      type: DataTypes.SMALLINT,
      allowNull: true,
      defaultValue: 0
    },
    Discontinued: {
      type: DataTypes.BOOLEAN,
      allowNull: false,
      defaultValue: false
    }
  }, {
    sequelize,
    tableName: 'Products',
    schema: 'dbo',
    timestamps: false,
    indexes: [
      {
        name: "CategoriesProducts",
        fields: [
          { name: "CategoryID" },
        ]
      },
      {
        name: "CategoryID",
        fields: [
          { name: "CategoryID" },
        ]
      },
      {
        name: "PK_Products",
        unique: true,
        fields: [
          { name: "ProductID" },
        ]
      },
      {
        name: "ProductName",
        fields: [
          { name: "ProductName" },
        ]
      },
      {
        name: "SupplierID",
        fields: [
          { name: "SupplierID" },
        ]
      },
      {
        name: "SuppliersProducts",
        fields: [
          { name: "SupplierID" },
        ]
      },
    ]
  });
};
