const Sequelize = require('sequelize');
module.exports = function(sequelize, DataTypes) {
  return sequelize.define('Region', {
    RegionID: {
      type: DataTypes.INTEGER,
      allowNull: false,
      primaryKey: true
    },
    RegionDescription: {
      type: DataTypes.CHAR(50),
      allowNull: false
    }
  }, {
    sequelize,
    tableName: 'Region',
    schema: 'dbo',
    timestamps: false,
    indexes: [
      {
        name: "PK_Region",
        unique: true,
        fields: [
          { name: "RegionID" },
        ]
      },
    ]
  });
};
