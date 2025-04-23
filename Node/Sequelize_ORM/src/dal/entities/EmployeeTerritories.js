const Sequelize = require('sequelize');
module.exports = function(sequelize, DataTypes) {
  return sequelize.define('EmployeeTerritories', {
    EmployeeID: {
      type: DataTypes.INTEGER,
      allowNull: false,
      primaryKey: true,
      references: {
        model: 'Employees',
        key: 'EmployeeID'
      }
    },
    TerritoryID: {
      type: DataTypes.STRING(20),
      allowNull: false,
      primaryKey: true,
      references: {
        model: 'Territories',
        key: 'TerritoryID'
      }
    }
  }, {
    sequelize,
    tableName: 'EmployeeTerritories',
    schema: 'dbo',
    timestamps: false,
    indexes: [
      {
        name: "PK_EmployeeTerritories",
        unique: true,
        fields: [
          { name: "EmployeeID" },
          { name: "TerritoryID" },
        ]
      },
    ]
  });
};
