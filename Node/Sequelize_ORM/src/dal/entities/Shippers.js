const Sequelize = require('sequelize');
module.exports = function(sequelize, DataTypes) {
  return sequelize.define('Shippers', {
    ShipperID: {
      autoIncrement: true,
      type: DataTypes.INTEGER,
      allowNull: false,
      primaryKey: true
    },
    CompanyName: {
      type: DataTypes.STRING(40),
      allowNull: false
    },
    Phone: {
      type: DataTypes.STRING(24),
      allowNull: true
    }
  }, {
    sequelize,
    tableName: 'Shippers',
    schema: 'dbo',
    timestamps: false,
    indexes: [
      {
        name: "PK_Shippers",
        unique: true,
        fields: [
          { name: "ShipperID" },
        ]
      },
    ]
  });
};
