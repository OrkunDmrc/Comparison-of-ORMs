const Sequelize = require('sequelize');
module.exports = function(sequelize, DataTypes) {
  return sequelize.define('TestData', {
    Id: {
      autoIncrement: true,
      type: DataTypes.INTEGER,
      allowNull: false,
      primaryKey: true
    },
    TestName: {
      type: DataTypes.STRING(50),
      allowNull: true
    },
    CpuUsage: {
      type: DataTypes.STRING(50),
      allowNull: true
    },
    MemoryUsage: {
      type: DataTypes.STRING(50),
      allowNull: true
    },
    Performance: {
      type: DataTypes.STRING(50),
      allowNull: true
    },
    Language: {
      type: DataTypes.STRING(50),
      allowNull: true
    }
  }, {
    sequelize,
    tableName: 'TestData',
    schema: 'dbo',
    timestamps: false,
    indexes: [
      {
        name: "PK__TestData__8CC3310000C56314",
        unique: true,
        fields: [
          { name: "Id" },
        ]
      },
    ]
  });
};
