const Sequelize = require('sequelize');
module.exports = function(sequelize, DataTypes) {
  return sequelize.define('Categories', {
    CategoryID: {
      autoIncrement: true,
      type: DataTypes.INTEGER,
      allowNull: false,
      primaryKey: true
    },
    CategoryName: {
      type: DataTypes.STRING(15),
      allowNull: false
    },
    Description: {
      type: DataTypes.TEXT,
      allowNull: true
    },
    Picture: {
      type: DataTypes.BLOB,
      allowNull: true
    }
  }, {
    sequelize,
    tableName: 'Categories',
    schema: 'dbo',
    timestamps: false,
    indexes: [
      {
        name: "CategoryName",
        fields: [
          { name: "CategoryName" },
        ]
      },
      {
        name: "PK_Categories",
        unique: true,
        fields: [
          { name: "CategoryID" },
        ]
      },
    ]
  });
};
