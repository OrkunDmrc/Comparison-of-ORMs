import { DataSource } from 'typeorm';
import * as dotenv from 'dotenv';

dotenv.config();

export const AppDataSource = new DataSource({
  type: 'mssql',
  host: process.env.HOST,//'localhost',
  port: Number(process.env.PORT),//1433,
  username: process.env.USER_NAME,//'sa',
  password: process.env.PASSWORD,//'123456',
  database: process.env.DATABASE_NAME,//'NorthwindTest',
  entities: ['src/dal/entities/**/*.ts'],
  synchronize: false,
  logging: true,
  options: {
    encrypt: true,
    trustServerCertificate: true,
  },
});