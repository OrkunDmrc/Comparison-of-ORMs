const { PrismaClient } = require('@prisma/client');

const prisma = new PrismaClient();

if (process.env.NODE_ENV === 'development') {
  prisma.$on('query', (e) => {
    console.log(`Query: ${e.query}`);
    console.log(`Params: ${e.params}`);
  });
}

module.exports = prisma;