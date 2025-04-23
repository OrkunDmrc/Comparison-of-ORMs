const Sequelize = require('sequelize');
module.exports = function(sequelize, DataTypes) {
  return sequelize.define('Territories', {
    TerritoryID: {
      type: DataTypes.STRING(20),
      allowNull: false,
      primaryKey: true
    },
    TerritoryDescription: {
      type: DataTypes.CHAR(50),
      allowNull: false
    },
    RegionID: {
      type: DataTypes.INTEGER,
      allowNull: false,
      references: {
        model: 'Region',
        key: 'RegionID'
      }
    }
  }, {
    sequelize,
    tableName: 'Territories',
    schema: 'dbo',
    timestamps: false,
    indexes: [
      {
        name: "PK_Territories",
        unique: true,
        fields: [
          { name: "TerritoryID" },
        ]
      },
    ]
  });
};
